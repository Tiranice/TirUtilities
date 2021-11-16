#if ENABLE_LEGACY_INPUT_MANAGER
using UnityEngine;
using UnityEngine.Events;

namespace TirUtilities.InputManagment
{
    ///<!--
    /// KeyboardBinding.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Oct 21, 2021
    /// Updated:  Oct 21, 2021
    /// -->
    /// <summary>
    /// Use to bind keyboard inputs to an object.
    /// </summary>
    [System.Serializable]
    public class KeyboardBinding
    {
        [SerializeField] private string _name = "New Key Binding";
        [SerializeField] private KeyCode _keyCode = KeyCode.None;
        [SerializeField] private KeyCode _modifierKeyCode = KeyCode.None;

        public UnityEvent OnKeyDown;
        public UnityEvent OnKeyUp;
        public UnityEvent OnKeyHeld;

        public KeyboardBinding(KeyCode keyBind, KeyCode modifierKeyBind = KeyCode.None, string name = "New Key Binding")
        {
            _keyCode = keyBind;
            _modifierKeyCode = modifierKeyBind;
            _name = name;
        }

        public string Name => _name;
        public KeyCode KeyBind => _keyCode;
        public KeyCode ModifierKeyBind => _modifierKeyCode;

        public bool KeyUp => ModifierKeyIsNone ? Input.GetKeyUp(_keyCode) : Input.GetKeyUp(_keyCode) && Input.GetKey(_modifierKeyCode);
        public bool KeyDown => ModifierKeyIsNone ? Input.GetKeyDown(_keyCode) : Input.GetKeyDown(_keyCode) && Input.GetKey(_modifierKeyCode);
        public bool KeyHeld => ModifierKeyIsNone ? Input.GetKey(_keyCode) : Input.GetKey(_keyCode) && Input.GetKey(_modifierKeyCode);

        private bool ModifierKeyIsNone => _modifierKeyCode == KeyCode.None;

        public override string ToString() => ModifierKeyIsNone ? $"{_name}:  {_keyCode}"
                                                               : $"{_name}:  {_keyCode} + {_modifierKeyCode}";

        public static implicit operator KeyboardBinding(KeyCode keyCode) =>
            new KeyboardBinding(keyCode);

        public static implicit operator KeyboardBinding((KeyCode, KeyCode) tuple) =>
            new KeyboardBinding(tuple.Item1, tuple.Item2);
    }
} 
#endif