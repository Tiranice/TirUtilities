#if ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine;

///<!--
/// InputDebugger.cs
/// 
/// Project:  TirUtilities
///        
/// Author :  Devon Wilson
/// Company:  Black Phoenix Software
/// Created:  Oct 21, 2021
/// Updated:  Oct 21, 2021
/// -->
/// <summary>
/// An example of how to get input from <see cref="TirUtilities.InputManagment.InputMessenger"/>.
/// </summary>
public class InputExample : MonoBehaviour
{
    /// <summary>
    /// This will be called if there is an <see cref="TirUtilities.InputManagment.AxisBinding"/>
    /// for the Horizontal axis.  It is protected to both stop access to it and to shut the IDE up.
    /// These work fine when private.
    /// </summary>
    /// <param name="value"></param>
    protected void OnHorizontal(float value)
    {
        if (value == 0) return;

        Debug.Log(value);
    }

    /// <summary>
    /// Same as above, but for a <see cref="TirUtilities.InputManagment.KeyboardBinding"/>.
    /// </summary>
    protected void OnSubmitDown() => Debug.Log("SubmitDown");

    /// <summary> Public methods can also be called with the UnityEvents on the bindings.
    public void EventListener() => Debug.Log("Event");
} 
#endif