using System.Collections.Generic;

using UnityEngine;

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
///     You should have received a copy of the GNU Lesser General Public License
///     along with this program.  If not, see <https://www.gnu.org/licenses/>.
///-->

namespace TirUtilities.Core
{
    ///<!--
    /// Destructor.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Jul 02, 2022
    /// Updated:  Jul 02, 2022
    /// -->
    /// <summary>
    /// Deactivates its target game objects on the given unity message.
    /// </summary>
    [AddComponentMenu("TirUtilities/Core/Deactivator")]
    public class Deactivator : MonoBehaviour
    {
        [System.Serializable]
        private enum TargetMessage { Awake, Start, OnEnable, }

        [SerializeField] private TargetMessage _targetMessage;
        [Space]
        [SerializeField] private List<GameObject> _targets;
        [Space]
        [SerializeField] private bool _destroyInBuilds = false;

        private void Awake()
        {
            if (_targetMessage is TargetMessage.Awake)
                Deactivate();
        }

        private void Start()
        {
            if (_targetMessage is TargetMessage.Start)
                Deactivate();
        }

        private void OnEnable()
        {
            if (_targetMessage is TargetMessage.OnEnable)
                Deactivate();
        }

        [ContextMenu(nameof(Deactivate))]
        public void Deactivate()
        {
            if (_destroyInBuilds && !Application.isEditor)
            {
                _targets?.ForEach(t => Destroy(t));
                return;
            }
            _targets?.ForEach(t => t.SetActive(false));
        }

        /// <summary> For use with <c>TriggerVolume</c>. </summary>
        public void DeactivateTarget(bool _, GameObject target) => target.SetActive(false);
    }
}