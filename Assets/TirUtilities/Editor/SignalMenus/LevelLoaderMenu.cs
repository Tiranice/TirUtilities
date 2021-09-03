using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace TirUtilities.Editor.SignalMenus
{
    using TirUtilities.Signals;

    ///<!--
    /// LevelLoaderMenu.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  Sep. 02, 2021
    /// Updated:  Sep. 02, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public sealed class LevelLoaderMenu : EditorWindow
    {
        #region Constants

        /// <summary>
        /// Height of the box each button group is placed in.
        /// </summary>
        private const int _ItemHeight = 28;

        #endregion

        #region Fields

        private static List<LevelLoadSignal> _Signals = new List<LevelLoadSignal>();
        private static readonly List<VisualElement> _Buttons = new List<VisualElement>();

        private static Vector2 _MaxWindowSize = new Vector2(1920, 720);

        private static LevelLoaderMenu _Window;

        #endregion

        #region Open & Close

        [MenuItem("TirUtilities/Level Loader Menu")]
        public static void Open()
        {
            _Window = GetWindow<LevelLoaderMenu>();
            _Window.titleContent = new GUIContent("Level Loader");
            _Window.maxSize = _MaxWindowSize;
        }

        #endregion

        #region Unity Messages

        private void CreateGUI()
        {
            FetchLevelLoadSignals();
            PopulateWindow();
        }

        private void Update()
        {
            _Buttons.ForEach(e
                => e.SetEnabled(EditorSceneManager.GetActiveScene().name != (e as Button).text));
        }

        #endregion

        #region Private Methods

        private void FetchLevelLoadSignals() 
            => _Signals = Resources.FindObjectsOfTypeAll<LevelLoadSignal>().ToList();

        private void PopulateWindow()
        {
            _Buttons.Clear();

            System.Func<VisualElement> makeBox = MakeBox;
            System.Action<VisualElement, int> bindBox = BindBox;

            var boxList = new ListView(_Signals, _ItemHeight, makeBox, bindBox)
            {
                selectionType = SelectionType.Single
            };

            boxList.style.flexGrow = 1.0f;

            rootVisualElement.Add(boxList);
        }

        private static void BindBox(VisualElement box, int index)
        {
            box.style.flexDirection = FlexDirection.Row;

            box.Add(BindButton(new Button(), index));

            var selectButton = new Button(() => Selection.activeObject = _Signals[index])
            {
                text = "Select"
            };

            selectButton.style.fontSize = _ItemHeight - 12;
            selectButton.style.unityFontStyleAndWeight = FontStyle.Bold;

            box.Add(selectButton);
        }

        private static VisualElement MakeBox() => new Box();

        private static VisualElement BindButton(Button button, int index)
        {
            _Buttons.Add(button);

            button.style.flexGrow = 1.0f;

            var activeScene = _Signals[index].ActiveScene;
            var start = activeScene.LastIndexOf('/') + 1;
            var end = activeScene.LastIndexOf(".unity");

            button .text = activeScene.Substring(start, end - start);

            button.style.fontSize = _ItemHeight - 12;
            button.style.unityFontStyleAndWeight = FontStyle.Bold;

            button.tooltip = "Click to load this signal's level data.";

            button .clicked += () => _Signals[index].LoadLevelData();

            return button;
        }

        #endregion
    }
}
