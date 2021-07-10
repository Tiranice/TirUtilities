using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

///<!--
/// RebindTest.cs
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
public class RebindTest : MonoBehaviour
{
    #region Inspector Fields

    [SerializeField] private InputActionReference _inputAction;
    [SerializeField] private TMP_Text _actionLabel;
    [SerializeField] private TMP_Text _bindingLabel;

    #endregion

    private InputActionRebindingExtensions.RebindingOperation _rebindingOperation;

    #region Unity Messages

    private void Start()
    {
        _actionLabel.SetText(_inputAction.action.name);
        _bindingLabel.SetText(_inputAction.action.GetBindingDisplayString(0));
    }

    #endregion

    #region Rebind Methods

    public void StartInteractiveRebind()
    {
        var action = _inputAction.action;
        if (action.bindings[0].isComposite)
        {
            int firstPartIndex = 1;

            if (firstPartIndex < action.bindings.Count && action.bindings[firstPartIndex].isPartOfComposite)
                Rebind(action, firstPartIndex, true);
        }
    }

    private void Rebind(InputAction action, int bindingIndex, bool allCompositeParts = false)
    {
        _rebindingOperation = action.PerformInteractiveRebinding(bindingIndex)
            .WithExpectedControlType("<Keyboard>")
            .WithCancelingThrough("<Keyboard>/escape")
            .OnComplete(operation => Rebinding__OnComplete(operation, action, bindingIndex));
        _rebindingOperation.Start();
    }

    private void CheckForDuplicate(InputAction action, int bindingIndex)
    {
        var bindingToCheck = action.bindings[bindingIndex];

        foreach (InputBinding binding in action.actionMap.bindings)
        {
            if (binding == bindingToCheck) continue;

            if (binding.effectivePath == bindingToCheck.effectivePath)
                action.RemoveBindingOverride(bindingToCheck);
        }
    }

    private void Rebinding__OnComplete(InputActionRebindingExtensions.RebindingOperation operation, InputAction action, int bindingIndex)
    {
        CheckForDuplicate(action, bindingIndex);
        _bindingLabel.SetText(action.GetBindingDisplayString(bindingIndex));
        _rebindingOperation.Dispose();
        _rebindingOperation = null;
        _bindingLabel.SetText(_inputAction.action.GetBindingDisplayString(0));
        Debug.Log("Done");
    }

    #endregion
}