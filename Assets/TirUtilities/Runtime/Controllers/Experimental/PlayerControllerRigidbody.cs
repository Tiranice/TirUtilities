using UnityEngine;
#if ENABLE_INPUT_SYSTEM
using UnityEngine.InputSystem;
#endif

namespace TirUtilities.Controllers.Experimental
{
    using TirUtilities.Extensions;

    ///<!--
    /// PlayerController.cs
    /// 
    /// Project:  TirUtilities
    ///        
    /// Author :  Devon Wilson
    /// Company:  Black Phoenix Software
    /// Created:  Sep 28, 2021
    /// Updated:  Sep 28, 2021
    /// -->
    /// <summary>
    ///
    /// </summary>
    public class PlayerControllerRigidbody : MonoBehaviour
    {
        #region Inspector Fields

        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField, Range(1.0f, 25.0f)] private float _speed;

        [SerializeField, DisplayOnly] Vector2 _movementVector = Vector2.zero;
        [SerializeField, DisplayOnly] bool _movePressed = false;

        #endregion

        #region Events & Signals

        //[Header("Signals")]
        //[SerializeField] private Vector2Signal _moveInputSignal;

        #endregion

        #region Unity Messages

        private void Awake()
        {
            if (_rigidbody.IsNull()) TryGetComponent(out _rigidbody);

            //_moveInputSignal.AddReceiver(MoveReceiver);
        }
#if ENABLE_INPUT_SYSTEM
        private void FixedUpdate() => Move();
#endif
        #endregion

        #region Input Messages
#if ENABLE_INPUT_SYSTEM
        public void OnMove(InputValue value) => MoveReceiver(value.Get<Vector2>());
#endif
        #endregion

        #region Private Methods

        private void MoveReceiver(Vector2 input) => _movementVector = input;

        private void Move()
        {
            var move = _movementVector.normalized.y * Camera.main.transform.forward;
            move.y = 0.0f;
            _rigidbody.AddForce(move * _speed);
        }

        #endregion
    }
}