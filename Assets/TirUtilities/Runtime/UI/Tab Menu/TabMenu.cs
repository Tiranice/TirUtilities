using System.Collections.Generic;
using System.Linq;

using UnityEngine;
using UnityEngine.UI;

///<!--
///     Copyright (C) 2025  Devon Wilson
///
///     This program is free software: you can redistribute it and/or modify
///     it under the terms of the GNU Lesser General Public License as published
///     by the Free Software Foundation, either version 3 of the License, or
///     (at your option) any later version.
///
///     This program is distributed in the hope that it will be useful,
///     but WITHOUT ANY WARRANTY; without even the implied warranty of
///     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
///     GNU Lesser General Public License for more details.
///
///     You should have received a copy of the GNU General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.UI.Experimental
{
    using TirUtilities.Signals;
    ///<!--
    /// TabMenu.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jul 03, 2021
    /// Updated:  Jul 03, 2021
    /// -->
    /// <summary>
    /// WARNING:  Uses tags and <c>GetChild</c>.  Use with caution.
    /// </summary>
    public class TabMenu : MonoBehaviour
    {
        [SerializeField] private GameObject _tabPanel;
        [DisplayOnly, SerializeField]
        private List<Button> _tabButtons;

        [SerializeField] private GameObjectSignal _gameObjectSignal;

        private void OnValidate()
        {
            _tabButtons = _tabPanel.GetComponentsInChildren<Button>().Where(button => button.CompareTag("GameController")).ToList();
            _tabButtons.Sort((i, j) => i.transform.GetSiblingIndex().CompareTo(j.transform.GetSiblingIndex()));
        }

        private void Start() => _gameObjectSignal.AddReceiver(ChangeTab);

        private void OnDestroy() => _gameObjectSignal.RemoveReceiver(ChangeTab);

        private void ChangeTab(GameObject target)
        {
            foreach (var button in _tabButtons) button.transform.GetChild(1).gameObject.SetActive(false);
            target.SetActive(true);
        }
    }
}