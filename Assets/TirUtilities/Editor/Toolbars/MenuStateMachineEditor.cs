using UnityEditor;
using UnityEditor.AnimatedValues;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.Editor
{
    using TirUtilities.Editor.Prefs;
    using TirUtilities.UI;
    //TODO :  Refactoring  
    //TODO :  Documentation
    ///<!--
    /// MenuStateMachineEditor.cs
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
    internal class MenuStateMachineEditor
    {
        private const float _ToolbarFixedHeight = 22.0f;

        #region Prefs Keys

        private const string _ToolbarEnabledPrefsKey = "TirUtilities.MenuStateMachine.ToolbarEnabled";
        private const string _ToolbarPositionPrefsKey = "TirUtilities.MenuStateMachine.ToolbarPosition";
        private const string _ToolbarCollapsePrefsKey = "TirUtilities.MenuStateMachine.ToolbarCollapse";

        #endregion

        #region Data Structures

        private readonly ref struct UIColors
        {
            public static Color Red => new Color(0.576f, 0.086f, 0.129f, 0.66f);
            public static Color Orange => new Color(0.843f, 0.306f, 0.035f, 0.66f);
        }

        #endregion

        #region Fields & Properties

        private static MenuStateMachineEditor _Instance;
        internal static MenuStateMachineEditor Instance => _Instance;

        private static Vector2 _ToolbarPosition = new Vector2(100.0f, 30.0f);
        private static Vector2 _ToolbarSize = new Vector2(200.0f, 100.0f);

        private static Vector2 _ScrollbarPosition = new Vector2();

        private static bool _ShouldMoveToolbar = false;
        private static MenuStateMachine _MenuStateMachine;

        private static AnimBool _ToolbarVisable;

        #endregion

        #region Style

        private static Texture2D _FoldoutCollapse, _FoldoutExpand, _CloseIcon;
        private static GUIStyle _FixedSizeStyle;

        #endregion

        #region Editor Prefs

        internal static EditorPrefsBool ToolbarEnabledPref { get; set; } =
            new EditorPrefsBool(_ToolbarEnabledPrefsKey, new GUIContent("Toolbar Enabled"), false);
        internal static EditorPrefsVector2 ToolbarPositionPref { get; set; } =
            new EditorPrefsVector2(_ToolbarPositionPrefsKey, new GUIContent(""), _ToolbarPosition);
        internal static EditorPrefsBool ToolbarCollapsePref { get; set; } =
            new EditorPrefsBool(_ToolbarCollapsePrefsKey, new GUIContent(""), true);

        #endregion

        #region Construction

        ~MenuStateMachineEditor() => EditorApplication.delayCall += Destroy;

        #endregion

        #region Private Setup & Teardown

        private void Initialize()
        {
            _Instance = this;
            _ToolbarVisable = new AnimBool(ToolbarCollapsePref);

            if (_MenuStateMachine == null) FetchMenuStateMachine();

            RegisterDelegates();
        }

        private void SetStyles()
        {
            _FoldoutCollapse = EditorGUIUtility.Load("IN foldout act") as Texture2D;
            _FoldoutExpand = EditorGUIUtility.Load("IN foldout act on") as Texture2D;
            _CloseIcon = EditorGUIUtility.Load("d_winbtn_win_close") as Texture2D;
            _FixedSizeStyle = new GUIStyle(GUI.skin.button)
            {
                stretchWidth = false,
                fixedHeight = _ToolbarFixedHeight
            };
        }
       
        private void RegisterDelegates()
        {
            UnregisterDelegates();
#if UNITY_2019_1_OR_NEWER
            SceneView.duringSceneGui += OnSceneGUI;
#else
			SceneView.onSceneGUIDelegate += OnSceneGUI;
#endif
            _ToolbarVisable.valueChanged.AddListener(new UnityAction(SceneView.RepaintAll));
        }

        private void Destroy()
        {
            UnregisterDelegates();
            _Instance = null;
            SceneView.RepaintAll();
        }

        private void UnregisterDelegates()
        {
#if UNITY_2019_1_OR_NEWER
            SceneView.duringSceneGui -= OnSceneGUI;
#else
			SceneView.onSceneGUIDelegate -= OnSceneGUI;
#endif
            _ToolbarVisable.valueChanged.RemoveListener(new UnityAction(SceneView.RepaintAll));
        }

        #endregion

        #region Internal Setup & Teardown

        internal static void Setup()
        {
            ToolbarEnabledPref.Value = true;

            _ToolbarPosition = ToolbarPositionPref;

            if (_Instance == null)
                new MenuStateMachineEditor().Initialize();
            else
                _Instance.Initialize();
        }

        internal static void SetupIfEnabled() { if (ToolbarEnabledPref.Value) Setup(); }

        
        internal static void Close()
        {
            ToolbarEnabledPref.Value = false;
            ToolbarPositionPref.Value = _ToolbarPosition;
            if (_Instance != null) _Instance.Destroy();
        }

        #endregion

        #region OnSceneGUI

        private void OnSceneGUI(SceneView view)
        {
            var currentEvent = Event.current;

            if (_MenuStateMachine == null) return;

            if (view == SceneView.lastActiveSceneView)
            {
                Handles.BeginGUI();
                DrawSceneToolbar();
                Handles.EndGUI();
            }
        }

        private static void FetchMenuStateMachine()
        {
            for (int i = 0; i < EditorSceneManager.sceneCount; i++)
            {
                foreach (var gameObject in EditorSceneManager.GetSceneAt(i).GetRootGameObjects())
                    if (gameObject.TryGetComponent<MenuStateMachine>(out var menuStateMachine))
                    {
                        _MenuStateMachine = menuStateMachine;
                        var previous = Selection.activeObject;
                        Selection.activeObject = _MenuStateMachine;
                        Selection.activeObject = previous;
                        //_MenuStateMachine.FetchMenuPages();
                        break;
                    }
            }
        }

        private void DrawSceneToolbar()
        {
            if (_MenuStateMachine == null)
            {
                Close();
                return;
            }

            SetStyles();
            var currentEvent = Event.current;

            UpdateToolbarPosition(currentEvent);

            using (new GUILayout.AreaScope(new Rect(_ToolbarPosition, _ToolbarSize)))
            {
                using (new GUILayout.HorizontalScope())
                {
                    FoldoutButton();
                    HeaderButton();
                    CloseButton();
                }

                using (var scroll = new GUILayout.ScrollViewScope(_ScrollbarPosition))
                {
                    _ScrollbarPosition = scroll.scrollPosition;
#if UNITY_2020_2_OR_NEWER
                    using var group = new EditorGUILayout.FadeGroupScope(_ToolbarVisable.faded);
                    if (group.visible)
                    {
                        foreach (var page in _MenuStateMachine.MenuPages)
                        {
                            if (page == null) continue;
                            if (page.State == null) continue;
                            if (GUILayout.Button(page.State.name))
                                Button_clicked(page);
                        }
                    }
#else
                    using (var group = new EditorGUILayout.FadeGroupScope(_ToolbarVisable.faded))
                    {
                        if (group.visible)
                        {
                            foreach (var page in _MenuStateMachine.MenuPages)
                            {
                                if (page == null) continue;
                                if (page.State == null) continue;
                                if (GUILayout.Button(page.State.name))
                                    Button_clicked(page);
                            }
                        }
                    }
#endif
                }
            }
        }
       
        private static void FoldoutButton()
        {
            if (_ToolbarVisable.target)
            {
                if (GUILayout.Button(_FoldoutCollapse, _FixedSizeStyle))
                {
                    _ToolbarVisable.target = false;
                    ToolbarCollapsePref.Value = false;
                    SceneView.RepaintAll();
                }
            }
            else if (GUILayout.Button(_FoldoutExpand, _FixedSizeStyle))
            {
                _ToolbarVisable.target = true;
                ToolbarCollapsePref.Value = true;
                SceneView.RepaintAll();
            }
        }
        
        private static void HeaderButton()
        {
            var lastColor = GUI.backgroundColor;
            GUI.backgroundColor = UIColors.Orange;
            var style = new GUIStyle(GUI.skin.button)
            {
                fontStyle = FontStyle.BoldAndItalic,
                fixedHeight = _ToolbarFixedHeight
            };
            _ShouldMoveToolbar =
                GUILayout.RepeatButton("Menu Pages", style);
            GUI.backgroundColor = lastColor;
        }

        private static void CloseButton()
        {
            var lastColor = GUI.backgroundColor;
            GUI.backgroundColor = UIColors.Red;
            
            if (GUILayout.Button(_CloseIcon, _FixedSizeStyle))
                Close();

            GUI.backgroundColor = lastColor;
        }
       
        private void UpdateToolbarPosition(Event currentEvent)
        {
            if ((currentEvent.type == EventType.MouseDrag) && _ShouldMoveToolbar)
            {
                _ToolbarPosition += currentEvent.delta;
                SceneView.RepaintAll();
            }
            if (currentEvent.type == EventType.MouseUp)
                ToolbarPositionPref.Value = _ToolbarPosition;
        }

        #endregion

        #region Click Callbacks

        private void Button_clicked(MenuPage page)
        {
            _MenuStateMachine.MenuPages.ForEach(p =>
            {
                if (p.State == page.State) page.ShowPanel();
                else p.HidePanel();
            });
        }

        #endregion
    }

    [InitializeOnLoad]
    internal static class MenuStateMachineEditorInitializer
    {
        static MenuStateMachineEditorInitializer() =>
            MenuStateMachineEditor.SetupIfEnabled();
    }
}