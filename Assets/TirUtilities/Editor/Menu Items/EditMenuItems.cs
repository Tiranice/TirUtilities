using UnityEditor;

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

namespace TirUtilities.Editor
{
    ///<!--
    /// EditMenuItems.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    /// Contains menu items found in Unity's edit menu.
    /// </summary>
    public static class EditMenuItems
    {
        /// <summary> Same as pressing the f key. </summary>
        private const string _FrameSelected = "Edit/Frame Selected";

        /// <summary>
        /// Selects and focuses the passed game object.
        /// </summary>
        /// <param name="gameObject"></param>
        public static void FocusSelected(GameObject gameObject)
        {
            Selection.activeObject = gameObject;
            EditorApplication.ExecuteMenuItem(_FrameSelected);
        }
    }
}