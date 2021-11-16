#if UNITY_EDITOR
using System.Collections.Generic;
using TirUtilities.Extensions;
using UnityEditor; 
using UnityEngine;

using static TirUtilities.TirLogger;

///<!--
/// NodeBasedEditor.cs
/// 
/// Project:  Project
///        
/// Author :  Author
/// Created:  Jan. 01, 2021
/// Updated:  Jan. 01, 2021
/// -->
/// <summary>
///
/// </summary>
public class NodeBasedEditor : EditorWindow
{
    #region Data Structures

    private List<NodeBase> _nodes;
    private List<Connection> _connections;

    #endregion

    #region Fields

    private GUIStyle _nodeStyle;
    private GUIStyle _inputStyle;
    private GUIStyle _outputStyle;

    private ConnectionPoint _selectedInput;
    private ConnectionPoint _selectedOutput;

    #endregion

    #region Open & Close

    [MenuItem("TirUtilities/Node Based Editor")]
    public static void Open()
    {
        var window = GetWindow<NodeBasedEditor>();
        window.titleContent = new GUIContent("Node Based Editor");
    }

    #endregion

    #region Unity Messages

    private void OnEnable()
    {
        SetNodeStyle();
        SetInputOutputStyle();
    }

    private void OnGUI()
    {
        DrawNodes();
        DrawConnections();

        ProcessNodeEvents(Event.current);
        ProcessEvents(Event.current);

        if (GUI.changed) Repaint();
    }

    #endregion

    #region Style Methods

    private void SetNodeStyle()
    {
        _nodeStyle = new GUIStyle() { border = new RectOffset(12, 12, 12, 12) };

        _nodeStyle.normal.background = EditorGUIUtility.Load("node1") as Texture2D;

    }

    private void SetInputOutputStyle()
    {
        _inputStyle = new GUIStyle() { border = new RectOffset(4, 4, 12, 12) };
        _inputStyle.normal.background = EditorGUIUtility.Load("btn left") as Texture2D;
        _inputStyle.active.background = EditorGUIUtility.Load("btn left on") as Texture2D;

        _outputStyle = new GUIStyle() { border = new RectOffset(4, 4, 12, 12) };
        _outputStyle.normal.background = EditorGUIUtility.Load("btn right") as Texture2D;
        _outputStyle.active.background = EditorGUIUtility.Load("btn right on") as Texture2D;
    }

    #endregion

    #region Draw Methods

    private void DrawNodes()
    {
        //LogCall(nameof(NodeBasedEditor), nameof(DrawNodes));

        if (_nodes.NotNull())
            _nodes.ForEach(node => node.Draw());
    }

    private void DrawConnections()
    {
        if (_connections.NotNull())
            _connections.ForEach(connection => connection.Draw());
    }

    #endregion

    #region Event Processors

    private void ProcessEvents(Event @event)
    {
        //LogCall(nameof(NodeBasedEditor), nameof(ProcessEvents));

        switch (@event.type)
        {
            case EventType.MouseDown:
                if (@event.button == 0)
                    ClearConnectionSelection();

                if (@event.button == 1)
                    AddNodeContextMenu(@event.mousePosition);
                break;
        }
    }

    private void ProcessNodeEvents(Event @event)
    {
        if (_nodes.NotNull())
        {
            for (int i = _nodes.Count - 1; i >= 0; i--)
            {
                GUI.changed = _nodes[i].ProcessEvents(@event);
                //bool guiChanged = _nodes[i].ProcessEvents(@event);
                //if (guiChanged) GUI.changed = true;
            }
        }
    }

    #endregion

    #region Context Menus

    private void AddNodeContextMenu(Vector2 mousePosition)
    {
        var genericMenu = new GenericMenu();
        genericMenu.AddItem(new GUIContent("Add node"), false, () => OnClickAddNode(mousePosition));
        genericMenu.ShowAsContext();
    }

    #endregion

    #region Callback Methods

    private void OnClickAddNode(Vector2 mousePosition)
    {
        if (_nodes.IsNull())
            _nodes = new List<NodeBase>();

        _nodes.Add(new NodeBase(mousePosition, 200, 50, string.Empty,
                   _nodeStyle, _inputStyle, _outputStyle,
                   OnClickInput, OnClickOutput));
    }

    private void OnClickInput(ConnectionPoint input)
    {
        _selectedInput = input;
        CreateConnection();
    }

    private void OnClickOutput(ConnectionPoint output)
    {
        _selectedOutput = output;
        CreateConnection();
    }

    private void OnClickRemoveConnection(Connection connection) => _connections.Remove(connection);

    #endregion

    #region Connections

    private void CreateConnection()
    {
        if (_selectedInput != null && _selectedOutput != null)
        {
            if (_selectedOutput.Node != _selectedInput.Node)
            {
                if (_connections.IsNull()) _connections = new List<Connection>();
                _connections.Add(new Connection(_selectedInput, _selectedOutput, OnClickRemoveConnection));
            }
            ClearConnectionSelection();
        }
    }

    private void ClearConnectionSelection()
    {
        _selectedInput = null;
        _selectedOutput = null;
    }

    #endregion
}

#endif