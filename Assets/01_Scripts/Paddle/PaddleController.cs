using UnityEngine;
using UnityEngine.InputSystem;

namespace Pong.Paddle
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(PlayerInput))]
    public class PaddleController : MonoBehaviour
    {
        public enum MovementMode
        {
            Inertialess = 0,
            Inertia = 1
        }

        [SerializeField] MovementMode _movement = MovementMode.Inertialess;
        [SerializeField] float _speed = 1f;
        [SerializeField] float _maxMovement = 3.5f;
        [SerializeField] float _speedSlewRate = 1f;

        Vector3 _originPoint;
        Rigidbody _paddleRB;
        float _inputMove;
        float _inputMoveWithInertia;

        private void Start()
        {
            _paddleRB = GetComponent<Rigidbody>();
            _originPoint = transform.position;
        }

        private void Update()
        {
            if (Mathf.Sign(_inputMove) != Mathf.Sign(_inputMoveWithInertia))
            {
                _inputMoveWithInertia = 0f;
            }

            _inputMoveWithInertia = Mathf.MoveTowards(_inputMoveWithInertia, _inputMove, _speedSlewRate * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (_movement == MovementMode.Inertialess)
            {
                //Calculate clamped new position
                float newZPosition = transform.position.z + (_inputMove * _speed * Time.deltaTime);
                newZPosition = Mathf.Clamp(newZPosition, -_maxMovement, _maxMovement);

                //Update position
                transform.position = _originPoint + new Vector3(0f, 0f, newZPosition);
            }
            else if (_movement == MovementMode.Inertia)
            {
                //Calculate clamped new position
                float newZPosition = transform.position.z + (_inputMoveWithInertia * _speed * Time.deltaTime);
                newZPosition = Mathf.Clamp(newZPosition, -_maxMovement, _maxMovement);

                //Update position
                transform.position = _originPoint + new Vector3(0f, 0f, newZPosition);
            }
        }

        private void OnMove(InputValue moveInput)
        {
            _inputMove = moveInput.Get<Vector2>().y;
        }
    }
}