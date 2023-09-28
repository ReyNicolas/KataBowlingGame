using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class Ball : MonoBehaviour
    {
        [SerializeField] Rigidbody rigidbody;
        [SerializeField] Transform spawnPoint;


        public void SetStartPosition()
        {
            rigidbody.velocity = Vector3.zero;
            transform.position = spawnPoint.position;
            transform.rotation = spawnPoint.rotation;
        }
    }

}

