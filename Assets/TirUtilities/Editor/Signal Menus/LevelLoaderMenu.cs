using System.Collections.Generic;
using System.Linq;

using UnityEditor;
using UnityEditor.SceneManagement;

using UnityEngine;
using UnityEngine.UIElements;

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

namespace TirUtilities.Editor.SignalMenus
{
    using TirUtilities.Signals;
    ///<!--
    /// LevelLoaderMenu.cs
    ///
    /// Project:  TirUtilities
    ///
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Creative
    /// Created:  Sep 02, 2021
    /// Updated:  Mar 26, 2025
    /// -->
    /// <summary>
    ///
    /// </summary>
    public sealed class LevelLoaderMenu : EditorWindow
    {
        /// <summary>
        /// Height of the box each button group is placed in.
        /// </summary>
        private const int _ItemHeight = 28;

        #region Fields

        /// <summary> List of all signals in asset database folders. </summary>
        private static readonly List<LevelLoadSignal> _Signals = new();

        /// <summary> List of all buttons created by the window. </summary>
        private static readonly List<VisualElement> _Buttons = new();

        private static Vector2 _MaxWindowSize = new(1920, 720);

        #endregion

        [MenuItem("Tools/TirUtilities/Level Loader Menu")]
        public static void Open()
        {
            var window = GetWindow<LevelLoaderMenu>();
            window.titleContent = new GUIContent("Level Loader");
            window.maxSize = _MaxWindowSize;
        }

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

            CreateRefreshButton();

            var boxList = new ListView(_Signals, _ItemHeight, MakeBox, BindBox)
            {
                selectionType = SelectionType.Single
            };

            boxList.style.flexGrow = 1.0f;

            rootVisualElement.Add(boxList);
        }

        private void CreateRefreshButton()
        {
            var refreshButton = new Button(Refresh) { text = "↻" };
            refreshButton.style.width = _ItemHeight;
            refreshButton.style.fontSize = _ItemHeight - 12;
            refreshButton.style.unityFontStyleAndWeight = FontStyle.Bold;

            rootVisualElement.Add(refreshButton);
        }

        private static VisualElement MakeBox()
        {
            var box = new Box();

            box.style.flexDirection = FlexDirection.Row;

            var loadButtion = new Button() { text = "No Active Scene" };
            box.Add(loadButtion);

            var selectButton = new Button() { text = "Select" };

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

            if (string.IsNullOrEmpty(activeScene))
                return button;

            var start = activeScene.LastIndexOf('/') + 1;
            var end = activeScene.LastIndexOf(".unity");

            button.text = activeScene[start..end];
            button.tooltip = "Click to load this signal's level data.";

            button.clicked += () => _Signals[index].LoadLevelData();

            return button;
        }

        #endregion
    }
}
