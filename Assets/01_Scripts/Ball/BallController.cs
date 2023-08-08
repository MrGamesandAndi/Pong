using UnityEngine;

namespace Pong.Ball
{
    [RequireComponent(typeof(Rigidbody))]
    public class BallController : MonoBehaviour
    {
        public enum LaunchDirection
        {
            Random = 0,
            TowardsPlayer1 = 1,
            TowardsPlayer2 = 2
        }

        [SerializeField] LaunchDirection _launchDirection = LaunchDirection.Random;
        [SerializeField] float _initialSpeed = 30f;
        [SerializeField] float _minimumSpeed = 20f;
        [SerializeField] float _maximumSpeed = 50f;

        Rigidbody _ballRB;

        private void Start()
        {
            _ballRB = GetComponent<Rigidbody>();
        }

        public void Launch()
        {

        }
    }
}
