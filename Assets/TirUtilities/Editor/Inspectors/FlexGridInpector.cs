using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace TirUtilities.Editor
{
    using TirUtilities.UI.Layout;

    using static TirUtilities.Editor.InspectorUtility;
    ///<!--
    /// FlexGridInpector.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Created:  May 15, 2021
    /// Updated:  June 19, 2021
    /// -->
    /// <summary>
    /// Draws the inspector for <see cref="FlexibleGridLayoutGroup"/>.
    /// </summary>
    [CustomEditor(typeof(FlexibleGridLayoutGroup))]
    public class FlexGridInpector : UnityEditor.Editor
    {
        #region Constants

        private const string _CellSizeLabel = "Cell Size";
        private const string _X = "X";
        private const string _Y = "Y";
        private const string _PaddingLable = "Padding";

        private const string _ExtraSettingsLabel = "<b>Extra Settings</b>";

        private const string _CellSize = "_cellSize";
        private const string _FitX = "_fitX";
        private const string _FitY = "_fitY";
        private const string _Script = "m_Script";
        private const string _FitType = "_fitType";
        private const string _Rows = "_rows";
        private const string _Columns = "_columns";
        private const string _Padding = "m_Padding";
        private const string _PaddingLeft = "m_Left";
        private const string _PaddingRight = "m_Right";
        private const string _PaddingTop = "m_Top";
        private const string RelativePropertyPath = "m_Bottom";

        #endregion

        #region Serialized Properties

        private List<SerializedProperty> _drawnProperites = new List<SerializedProperty>();
        private SerializedProperty _fitTypeToDisplay;

        #endregion

        #region Private Fields

        private bool _foldExtraSettings = false;
        private readonly string[] _uiStateLabel = new string[] { "<i>(Click to collapse)</i> ", "<i>(Click to expand)</i> " };
        
        #endregion

        #region Overrides

        public override void OnInspectorGUI() => DrawInspector();

        #endregion

        #region Draw Inspector

        /// <summary> Draws the full inspector. </summary>
        /// <returns> The value of EditorGUI.EndChangeCheck(). </returns>
        private bool DrawInspector()
        {
            EditorGUI.BeginChangeCheck();

            serializedObject.UpdateIfRequiredOrScript();

            SerializedProperty propertyIterator = serializedObject.GetIterator();

            ScriptProperty(propertyIterator);

            FitTypeProperty();
            RowColumnProperties();
            CellSizeProperty();

            EditorGUILayout.Space(10);
            ExtraSettings();

            _drawnProperites.Add(serializedObject.FindProperty("m_ChildAlignment"));

            DrawRest(propertyIterator);

            serializedObject.ApplyModifiedProperties();
            return EditorGUI.EndChangeCheck();
        }

        #endregion

        #region Draw Methods

        /// <summary> Draw the first property in an iterator. </summary>
        /// <param name="property"></param>
        private static void ScriptProperty(SerializedProperty property)
        {
            property.NextVisible(true);
            using (new EditorGUI.DisabledScope(_Script == property.propertyPath))
            {
                EditorGUILayout.PropertyField(property, true);
            }
        }

        /// <summary> Draw the fit type. </summary>
        private void FitTypeProperty()
        {
            _fitTypeToDisplay = serializedObject.FindProperty(_FitType);
            EditorGUILayout.PropertyField(_fitTypeToDisplay);
            EditorGUILayout.Space();

            _drawnProperites.Add(_fitTypeToDisplay);
        }

        /// <summary> Draws the rows and columns. </summary>
        private void RowColumnProperties()
        {
            SerializedProperty rows = serializedObject.FindProperty(_Rows);
            SerializedProperty columns = serializedObject.FindProperty(_Columns);

            var fitType = (FitType)_fitTypeToDisplay.enumValueIndex;

            if (fitType.DistributesEvenly())
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(rows);
                    EditorGUILayout.PropertyField(columns);
                }
            }
            else if (fitType == FitType.FixedRows)
            {
                EditorGUILayout.PropertyField(rows);
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(columns);
                }
            }
            if (fitType == FitType.FixedColumns)
            {
                using (new EditorGUI.DisabledScope(true))
                {
                    EditorGUILayout.PropertyField(rows);
                }
                EditorGUILayout.PropertyField(columns);
            }

            _drawnProperites.Add(rows);
            _drawnProperites.Add(columns);
            EditorGUILayout.Space();
        }
        
        private void CellSizeProperty()
        {
            float old_LabelWidth = EditorGUIUtility.labelWidth;
            float old_FieldWidth = EditorGUIUtility.fieldWidth;

            Rect controlRect = EditorGUILayout.GetControlRect(false);

            var origin = new Rect(controlRect.x, controlRect.y, old_LabelWidth, controlRect.height);

            // Field Label
            GUI.Label(origin, _CellSizeLabel);

            var cellSize = serializedObject.FindProperty(_CellSize);
            Vector2 tempVec = Vector2.zero;
            tempVec.x = cellSize.FindPropertyRelative(_X.ToLower()).floatValue;
            tempVec.y = cellSize.FindPropertyRelative(_Y.ToLower()).floatValue;

            float fieldWidth = 80;
            origin.width = fieldWidth;

            var fitX = serializedObject.FindProperty(_FitX).boolValue;
            var fitY = serializedObject.FindProperty(_FitY).boolValue;

            tempVec = DrawVector2Field(old_LabelWidth, _X, _Y, origin, tempVec, fieldWidth, fitX, fitY);

            cellSize.FindPropertyRelative(_X.ToLower()).floatValue = tempVec.x;
            cellSize.FindPropertyRelative(_Y.ToLower()).floatValue = tempVec.y;

            EditorGUIUtility.labelWidth = old_LabelWidth;
            EditorGUIUtility.fieldWidth = old_FieldWidth;

            _drawnProperites.Add(cellSize);
        }

        private void ExtraSettings()
        {
            Rect rect = EditorGUILayout.GetControlRect(false, 24);

            var sectionHeader = new GUIStyle(EditorStyles.label)
            {
                fixedHeight = 22,
                richText = true,
                border = new RectOffset(9, 9, 0, 0),
                overflow = new RectOffset(9, 0, 0, 0),
                padding = new RectOffset(0, 0, 4, 0)
            };
            sectionHeader.normal.background = Texture2D.grayTexture;

            if (GUI.Button(rect, new GUIContent(_ExtraSettingsLabel), sectionHeader))
            {
                _foldExtraSettings = !_foldExtraSettings;
            }
            var rightLabel = new GUIStyle(EditorStyles.label)
            {
                alignment = TextAnchor.MiddleRight,
                richText = true
            };

            GUI.Label(rect, (_foldExtraSettings ? _uiStateLabel[0] : _uiStateLabel[1]), rightLabel);

            FitProperties();
            PaddingProperty(_PaddingLable);
            SpaceAroundProperty();
        }

        private void FitProperties()
        {
            var fitX = serializedObject.FindProperty(_FitX);
            var fitY = serializedObject.FindProperty(_FitY);

            if (_foldExtraSettings)
            {
                EditorGUILayout.PropertyField(fitX);
                EditorGUILayout.PropertyField(fitY);
            }

            _drawnProperites.Add(fitX);
            _drawnProperites.Add(fitY);
        }

        private void PaddingProperty(string label)
        {
            var padding = serializedObject.FindProperty(_Padding);
            _drawnProperites.Add(padding);

            if (!_foldExtraSettings) return;

            float old_LabelWidth = EditorGUIUtility.labelWidth;
            float old_FieldWidth = EditorGUIUtility.fieldWidth;

            Rect rect = EditorGUILayout.GetControlRect(false, 2 * 18);
            var pos0 = new Rect(rect.x, rect.y + 2, rect.width, 18);

            float width = rect.width + 3;
            pos0.width = old_LabelWidth;
            GUI.Label(pos0, label);

            Vector4 vec = Vector4.zero;
            vec.x = padding.FindPropertyRelative(_PaddingLeft).intValue;
            vec.y = padding.FindPropertyRelative(_PaddingRight).intValue;
            vec.z = padding.FindPropertyRelative(_PaddingTop).intValue;
            vec.w = padding.FindPropertyRelative(RelativePropertyPath).intValue;


            float widthB = width - old_LabelWidth;
            float fieldWidth = widthB / 4;
            pos0.width = fieldWidth - 5;

            // Labels
            pos0.x = old_LabelWidth + 15;
            GUI.Label(pos0, "Left");

            pos0.x += fieldWidth;
            GUI.Label(pos0, "Right");

            pos0.x += fieldWidth;
            GUI.Label(pos0, "Top");

            pos0.x += fieldWidth;
            GUI.Label(pos0, "Bottom");

            pos0.y += 18;

            pos0.x = old_LabelWidth + 15;
            vec.x = EditorGUI.FloatField(pos0, GUIContent.none, vec.x);

            pos0.x += fieldWidth;
            vec.y = EditorGUI.FloatField(pos0, GUIContent.none, vec.y);

            pos0.x += fieldWidth;
            vec.z = EditorGUI.FloatField(pos0, GUIContent.none, vec.z);

            pos0.x += fieldWidth;
            vec.w = EditorGUI.FloatField(pos0, GUIContent.none, vec.w);

            padding.FindPropertyRelative("m_Left").intValue = (int)vec.x;
            padding.FindPropertyRelative("m_Right").intValue = (int)vec.y;
            padding.FindPropertyRelative("m_Top").intValue = (int)vec.z;
            padding.FindPropertyRelative("m_Bottom").intValue = (int)vec.w;

            EditorGUIUtility.labelWidth = old_LabelWidth;
            EditorGUIUtility.fieldWidth = old_FieldWidth;
        }

        private void SpaceAroundProperty()
        {
            var spaceAround = serializedObject.FindProperty("_spaceAround");
            _drawnProperites.Add(spaceAround);
            if (_foldExtraSettings)
            {
                EditorGUILayout.PropertyField(spaceAround);
            }
        }

        private void DrawRest(SerializedProperty property)
        {
            while (property.NextVisible(false))
            {
                if (!_drawnProperites.Exists(i => i.propertyPath == property.propertyPath))
                    EditorGUILayout.PropertyField(property, true);
            }
        }

        #endregion
    }
}