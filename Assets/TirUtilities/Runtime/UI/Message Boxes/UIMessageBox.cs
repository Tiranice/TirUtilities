using TMPro;

using UnityEngine;
using UnityEngine.Events;
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

namespace TirUtilities.UI
{
    using TirUtilities.Extensions;
    ///<!--
    /// UIMessageBox.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Mar 29, 2021
    /// Updated:  Mar 29, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class UIMessageBox : MonoBehaviour
    {
        [SerializeField][TextArea] private string _text;
        [Space(20)]

        [SerializeField] private Button _dismissButton;
        [Space(20)]

        [SerializeField] private TextMeshProUGUI _textUGUI;
        [SerializeField] private TextMeshProUGUI _icon;
        [Space(20)]

        public UnityEvent OnDissmissed;

        private void OnValidate()
        {
            if (_textUGUI.NotNull())
                _textUGUI.text = _text;
        }

        private void Start() => _dismissButton.onClick.AddListener(() => gameObject.SetActive(false));
    }
}