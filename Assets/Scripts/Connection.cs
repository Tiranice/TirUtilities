#if UNITY_EDITOR
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

///<!--
/// Connection.cs
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
public class Connection
{
    #region Data Structures

    #endregion

    #region Fields

    private ConnectionPoint _input;
    private ConnectionPoint _output;

    #endregion

    #region Events

    private event Action<Connection> OnClickRemoveConnection;

    #endregion

    #region Constructor

    public Connection(ConnectionPoint input, ConnectionPoint output, Action<Connection> OnClickRemoveCallback)
    {
        _input = input;
        _output = output;

        OnClickRemoveConnection = OnClickRemoveCallback;
    }

    #endregion

    #region Public Methods

    public void Draw()
    {
        Handles.DrawBezier(
            startPosition: _input.Center,
            endPosition: _output.Center,
            startTangent: _input.Center + Vector2.left * 50.0f,
            endTangent: _output.Center - Vector2.left * 50.0f,
            color: Color.white,
            texture: null,
            width: 2.0f
            );

        if (Handles.Button((_input.Center + _output.Center) * 0.5f, Quaternion.identity, 4, 8, Handles.RectangleHandleCap))
            OnClickRemoveConnection?.Invoke(this);
    }

    #endregion

}
#endif