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

namespace TirUtilities.UI.Buttons
{
    ///<!--
    /// ButtonHotKey.cs
    ///
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Feb 22, 2021
    /// Updated:  Feb 22, 2021
    /// -->
    /// <summary>
    /// Invokes the OnClick event on a button.
    /// </summary>
    [RequireComponent(typeof(Button))]
    public class ButtonHotKey : MonoBehaviour
    {
        [SerializeField] private KeyCode _hotKey;
        [SerializeField] private Button _button;

        private void Awake() => TryGetComponent(out _button);

        private void Update()
        {
            if (ShouldInvokeOnClick) _button.onClick.Invoke();
        }

        /// <summary>
        /// True is the hot-key has been pressed and the button is active.
        /// </summary>
        private bool ShouldInvokeOnClick => Input.GetKeyDown(_hotKey) && _button.IsActive();
    }
}