using System;
using UnityEngine;

///<!--
/// ConnectionPoint.cs
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
public class ConnectionPoint
{
    #region Fields

    private Rect _rect;
    private readonly ConnectionPointType _type;
    private readonly NodeBase _node;
    private readonly GUIStyle _style;

    #endregion

    #region Events

    public event Action<ConnectionPoint> OnClick;

    #endregion

    #region Constructor

    public ConnectionPoint(ConnectionPointType type, NodeBase node, GUIStyle style, Action<ConnectionPoint> OnClickCallback)
    {
        _rect = new Rect(0.0f, 0.0f, 10.0f, 20.0f);
        _type = type;
        _node = node;
        _style = style;

        OnClick = OnClickCallback;
    }

    #endregion

    #region Public Methods

    public void Draw()
    {
        _rect.y = _node.GetRect.y + _node.HalfHeight - (_rect.height * 0.5f);

        _rect.x = _type switch
        {
            ConnectionPointType.In => _node.GetRect.x - _rect.width + 8.0f,
            ConnectionPointType.Out => _node.GetRect.x + _node.GetRect.width - 8.0f,
            _ => _rect.x
        };

        if (GUI.Button(_rect, string.Empty, _style))
            OnClick?.Invoke(this);
    }

    #endregion

    #region Public Properties

    public Vector2 Center => _rect.center;

    public NodeBase Node => _node;

    #endregion
}