using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor.Experimantal
{
    ///<!--
    /// EditMenuItems.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
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