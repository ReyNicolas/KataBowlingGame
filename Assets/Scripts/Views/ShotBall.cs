using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class ShotBall : MonoBehaviour
    {
        [SerializeField] private GameObject ball;
        [SerializeField, Range(100f, 1000f)] float force = 1000f;
        private Rigidbody ballRigidbody;
        Vector3 direction = new Vector3(0, 0, -2);

        private void Start()
        {
            ballRigidbody = ball.GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            float magnitude = ballRigidbody.velocity.magnitude;
            if (magnitude < 100 && magnitude > 1) ballRigidbody.AddForce(direction * 100f * Time.deltaTime);
        }

        public void Shot()
        {
            


            ballRigidbody.AddForce(direction * force);
        }

    }

}
