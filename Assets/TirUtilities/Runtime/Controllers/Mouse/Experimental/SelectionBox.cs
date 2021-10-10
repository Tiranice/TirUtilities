using System.Collections;
using System.Collections.Generic;
using TirUtilities.Signals;
using UnityEngine;

namespace TirUtilities.Controllers.Experimental
{
    ///<!--
    /// SelectionBox.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  BlackPhoenixSoftware
    /// Created:  Oct 01, 2021
    /// Updated:  Oct 01, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class SelectionBox : MonoBehaviour
    {
        #region Inspector Fields

        [Header("UI Components")]
        [SerializeField] private RectTransform _boxRect;
        [SerializeField] private List<Transform> _triggerCorners;

        [Header("World Space Components")]
        [SerializeField] private Transform _triggerVolume;
        [SerializeField] private List<GameObject> _selectedObjects = new List<GameObject>();

        #endregion

        #region Events & Signals

        [Header("Input Signals")]
        [SerializeField] private BoolSignal _toggleSignal;
        [SerializeField] private Vector2Signal _mousePosSignal;

        #endregion

        #region Private Fields

        private Camera _mainCamera;

        private Vector2 _mousePosition = Vector2.zero;
        private Vector2 _startPosition = Vector2.zero;

        private readonly Vector3[] _boxWorldCorners = new Vector3[4];

        #endregion

        #region Unity Messages

        private void Awake()
        {
            _mainCamera = Camera.main;
            AssignSignalReceivers();
        }

        private void Update() => SetBoxSize();

        private void OnDestroy() => RemoveSignalReceivers();

        #endregion

        #region Setup & Teardown

        private void AssignSignalReceivers()
        {
            _toggleSignal.AddReceiver(ToggleSignalReceiver);
            _mousePosSignal.AddReceiver(MousePosReceiver);
        }

        private void RemoveSignalReceivers()
        {
            _toggleSignal.RemoveReceiver(ToggleSignalReceiver);
            _mousePosSignal.RemoveReceiver(MousePosReceiver);
        }

        #endregion

        #region Signal Receivers

        private void MousePosReceiver(Vector2 val) => _mousePosition = val;
        private void ToggleSignalReceiver(bool val)
        {
            _boxRect.gameObject.SetActive(val);
            _startPosition = _mousePosition;
        }

        #endregion

        #region Selection Methods

        private void SetBoxSize()
        {
            if (!_boxRect.gameObject.activeSelf) return;

            var size = _mousePosition - _startPosition;
            var halfSize = size * 0.5f;

            _boxRect.sizeDelta = size.Abs();
            _boxRect.anchoredPosition = _startPosition + halfSize;

            _boxRect.GetWorldCorners(_boxWorldCorners);

            var boxWorldSpaceCenter = Vector3.zero;

            for (int i = 0; i < _boxWorldCorners.Length; i++)
            {
                if (Physics.Raycast(_mainCamera.ScreenPointToRay(_boxWorldCorners[i]), out var hit))
                {
                    _triggerCorners[i].position = hit.point;
                    boxWorldSpaceCenter += hit.point;
                }
            }

            SetTriggerTransform(boxWorldSpaceCenter);
        }

        private void SetTriggerTransform(Vector3 boxWorldSpaceCenter)
        {
            _triggerVolume.position = boxWorldSpaceCenter * 0.25f;

            _triggerVolume.localScale = new Vector3(
                Vector3.Distance(_triggerCorners[0].position, _triggerCorners[3].position),
                20.0f,
                Vector3.Distance(_triggerCorners[0].position, _triggerCorners[1].position));

            _triggerVolume.rotation = Quaternion.Euler(
                new Vector3(0.0f,
                            _mainCamera.transform.rotation.eulerAngles.y,
                            0.0f));
        }

        public void UpdateSelection(bool entered, GameObject target)
        {
            if (entered)
            {
                if (!TryGetComponent<ISelectable>(out var selectable)) return;
                selectable.Select();

                _selectedObjects.Add(target);
            }
            else
            {
                if (!TryGetComponent<ISelectable>(out var selectable)) return;
                selectable.Deselect();

                _selectedObjects.Remove(target);
            }
        }

        #endregion

        #region Public Properties

        public IReadOnlyList<GameObject> SelectedObjects => _selectedObjects;

        #endregion
    }
}