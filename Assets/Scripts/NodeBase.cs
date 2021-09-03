using System;
using UnityEngine;

///<!--
/// NodeBase.cs
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
public class NodeBase
{
    #region Fields

    private Rect _rect;

    private readonly string _title;
    private readonly GUIStyle _style;

    private readonly ConnectionPoint _input;
    private readonly ConnectionPoint _output;

    public bool IsDragged { get; set; }

    #endregion
        
    #region Constructor
    
    public NodeBase(Vector2 position, float width, float height, string title, GUIStyle nodeStyle, 
                    GUIStyle inputStyle, GUIStyle outputStyle, Action<ConnectionPoint> OnClickInput,
                    Action<ConnectionPoint> OnClickOutput)
    {
        _rect = new Rect(position.x, position.y, width, height);
        _title = title;
        _style = nodeStyle;

        _input = new ConnectionPoint(ConnectionPointType.In, this, inputStyle, OnClickInput);
        _output = new ConnectionPoint(ConnectionPointType.Out, this, outputStyle, OnClickOutput);
    }

    #endregion

    #region Public Methods

    public void Drag(Vector2 delta) => _rect.position += delta;

    public void Draw()
    {
        _input.Draw();
        _output.Draw();
        GUI.Box(_rect, _title, _style);
    }

    public bool ProcessEvents(Event @event)
    {
        switch (@event.type)
        {
            case EventType.MouseUp:
                IsDragged = false;
                break;

            case EventType.MouseDown:
                if (@event.button == 0)
                {
                    if (_rect.Contains(@event.mousePosition))
                        IsDragged = true;
                    GUI.changed = true;
                }
                break;

            case EventType.MouseDrag:
                if (@event.button == 0 && IsDragged)
                {
                    Drag(@event.delta);
                    @event.Use();
                    return true;
                }
                break;
        }
        return false;
    }

    #endregion

    #region Public Properties

    public Rect GetRect => _rect;
    public float HalfHeight => _rect.height * 0.5f;

    #endregion
}