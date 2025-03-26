using UnityEditor;

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
    /// MenuStateMachineMenuItems.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 06, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    ///
    /// </summary>
    static internal class MenuStateMachineMenuItems
    {
        [MenuItem("TirUtilities/Menu State Machine/Open Scene Toolbar")]
        internal static void InitSceneToolbar()
        {
            MenuStateMachineEditor.Setup();
            SceneView.RepaintAll();
        }
    }
}