using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UIElements;

namespace TirUtilities.Editor.SignalMenus
{
    using TirUtilities.Signals;
    using static TirLogger;
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

        /// <summary> List of all signals in asset database folders. </summary>
        private static readonly List<LevelLoadSignal> _Signals = new List<LevelLoadSignal>();

        /// <summary> List of all buttons created by the window. </summary>
        private static readonly List<VisualElement> _Buttons = new List<VisualElement>();

        private static Vector2 _MaxWindowSize = new Vector2(1920, 720);

        #endregion

        #region Open & Close

        [MenuItem("TirUtilities/Level Loader Menu")]
        public static void Open()
        {
            var window = GetWindow<LevelLoaderMenu>();
            window.titleContent = new GUIContent("Level Loader");
            window.maxSize = _MaxWindowSize;
        }

        #endregion

        #region Unity Messages

        private void CreateGUI()
        {
            FetchLevelLoadSignals();
            PopulateWindow();
        }

        private void OnProjectChange() => Refresh();        

        private void Update()
        {
            _Buttons.ForEach(e
                => e.SetEnabled(EditorSceneManager.GetActiveScene().name != (e as Button).text));
        }

        #endregion

        #region Setup & Teardown

        /// <summary>
        /// Load all of <see cref="LevelLoadSignal"/> assets from the asset database.
        /// </summary>
        private void FetchLevelLoadSignals()
        {
            _Signals.Clear();

            var assetPaths = new List<string>();

            foreach (var guid in AssetDatabase.FindAssets($"t:{nameof(LevelLoadSignal)}"))
                assetPaths.Add(AssetDatabase.GUIDToAssetPath(guid));

            foreach (var path in assetPaths)
                _Signals.Add(AssetDatabase.LoadAssetAtPath<LevelLoadSignal>(path));
        }

        #endregion

        #region Draw Methods

        /// <summary>
        /// Draw the list view and all child elements.
        /// </summary>
        private void PopulateWindow()
        {
            _Buttons.Clear();

            if (_Signals.Count < 1) return;

            var refreshButton = new Button(Refresh)
            {
                text = "↻"
            };
            refreshButton.style.width = _ItemHeight;
            refreshButton.style.fontSize = _ItemHeight - 12;
            refreshButton.style.unityFontStyleAndWeight = FontStyle.Bold;

            rootVisualElement.Add(refreshButton);

            var boxList = new ListView(_Signals, _ItemHeight, MakeBox, BindBox)
            {
                selectionType = SelectionType.Single
            };

            boxList.style.flexGrow = 1.0f;

            rootVisualElement.Add(boxList);
        }

        private static VisualElement MakeBox()
        {
            var box = new Box();

            box.style.flexDirection = FlexDirection.Row;

            var loadButtion = new Button() { text = "No Active Scene" };
            box.Add(loadButtion);

            var selectButton = new Button()
            {
                text = "Select"
            };

            selectButton.style.fontSize = _ItemHeight - 12;
            selectButton.style.unityFontStyleAndWeight = FontStyle.Bold;

            box.Add(selectButton);

            return box;
        }

        private void Refresh()
        {
            FetchLevelLoadSignals();
            rootVisualElement.Clear();
            PopulateWindow();
        }

        #endregion

        #region List View Callbacks

        private static void BindBox(VisualElement box, int index)
        {
            var children = box.Children().ToList();
            BindButton(children[0] as Button, index);

            (children[1] as Button).clicked += () => Selection.activeObject = _Signals[index];
        }

        private static VisualElement BindButton(Button button, int index)
        {
            _Buttons.Add(button);

            button.style.flexGrow = 1.0f;
            button.style.fontSize = _ItemHeight - 12;
            button.style.unityFontStyleAndWeight = FontStyle.Bold;

            var activeScene = _Signals[index].ActiveScene;

            if (activeScene == string.Empty || activeScene == null)
                return button;

            var start = activeScene.LastIndexOf('/') + 1;
            var end = activeScene.LastIndexOf(".unity");

            button.text = activeScene.Substring(start, end - start);
            button.tooltip = "Click to load this signal's level data.";

            button.clicked += () => _Signals[index].LoadLevelData();

            return button;
            
        }

        #endregion
    }
}
