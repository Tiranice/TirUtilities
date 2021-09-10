using UnityEditor;

namespace TirUtilities.Editor
{
    ///<!--
    /// MenuStateMachineMenuItems.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Sep. 06, 2021
    /// Updated:  Sep. 09, 2021
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