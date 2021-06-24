using TMPro;
using UnityEngine;

namespace TirUtilities.UI
{
    ///<!--
    /// UIBillboard.cs
    /// 
    /// Project:  TirUtilities
    /// 
    /// Author :  Devon Wilson  
    /// Created:  Feb. 22, 2021
    /// Updated:  May 01, 2021
    /// -->
    /// <summary>
    /// Turns the attached canvas to face the main camera and sets the text of the child TMP text
    /// component.
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class UIBillboard : MonoBehaviour
    {
        #region Inspector Fields

        [Tooltip("This text will fill the TMPro text attached to the first child.")]
        [TextArea]
        [SerializeField] private string _text;

        [Tooltip("The transform of the main camera.")]
        [SerializeField] private Transform _mainCamera;

        #endregion

        #region Private Fields

        /// <summary> The canvas attached to this game object. </summary>
        private Canvas _canvas;

        /// <summary> The point that this game object will turn to look at. </summary>
        private Vector3 _lookAt;

        /// <summary> The camera's up vector. </summary>
        private Vector3 _up;

        #endregion

        #region Properties

        /// <summary> Get and set the <see cref="_text">Text</see> displayed on the billboard. </summary>
        public string Text { get => _text; set => _text = value; }

        #endregion

        #region Unity Messages

#if UNITY_EDITOR
        private void OnValidate() => SetTMPTextInChild();
#endif

        private void Awake() => Setup();

        private void LateUpdate() => UpdateBillboardRotation();

        #endregion

        #region Setup & Teardown

        /// <summary> Cache needed references. </summary>
        private void Setup()
        {
            if (_mainCamera == null) _mainCamera = Camera.main.transform;
            if (_canvas == null) _canvas = GetComponent<Canvas>();
            _canvas.worldCamera = Camera.main;
        }

        #endregion

        #region Update Billboard

#if UNITY_EDITOR
        [ContextMenu(nameof(SetTextFromParentName))]
        private void SetTextFromParentName()
        {
            _text = transform.parent.name;
            SetTMPTextInChild();
        }

        /// <summary>
        /// Use the content of the <see cref="_text">Text Area</see> to set the text of the top
        /// TMPText in this game object's children.
        /// </summary>
        private void SetTMPTextInChild()
        {
            var tmpText = GetComponentInChildren<TextMeshProUGUI>(includeInactive: true);
            if (tmpText != null)
                tmpText.text = _text;

            else
                Debug.LogError(
                    $"No TMPText attached to any children of {name}, child of {transform.parent.name}."
                    );
        }
#endif

        /// <summary>
        /// Turn the billboard to look at the <see cref="_mainCamera">Main Camera</see>.
        /// </summary>
        private void UpdateBillboardRotation()
        {
            _lookAt = transform.position + _mainCamera.rotation * Vector3.forward;
            _up = _mainCamera.rotation * Vector3.up;
            transform.LookAt(_lookAt, _up);
        }

        #endregion
    }
}