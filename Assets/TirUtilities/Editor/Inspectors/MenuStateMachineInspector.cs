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

namespace TirUtilities.Editor.Experimental
{
    using TirUtilities.UI;
    ///<!--
    /// MenuStateMachineInspector.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  July 05, 2021
    /// Updated:  Sep. 09, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    [CustomEditor(typeof(MenuStateMachine))]
    public class MenuStateMachineInspector : UnityEditor.Editor
    {
        private MenuStateMachine _menuStateMachine;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            FetchSceneMenuPages();
        }

        private void FetchSceneMenuPages()
        {
            if (_menuStateMachine == null)
                _menuStateMachine = serializedObject.targetObject as MenuStateMachine;

            _menuStateMachine.MenuPages.Clear();
            _menuStateMachine.MenuPages.AddRange(FindObjectsOfType<MenuPage>());
            _menuStateMachine.MenuPages.Sort((i, j) => i.transform.GetSiblingIndex().CompareTo(j.transform.GetSiblingIndex()));
        }
    }
}
