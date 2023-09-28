using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Views
{
    public class Pin : MonoBehaviour
    {
        [SerializeField] private List<Transform> pins;
        int numberOfPinsHitDown = 0;

        public void ResetCount()
        {
            numberOfPinsHitDown = 0;
        }

        public void CheckPinsDown()
        {
            foreach (Transform pin in pins)
            {
                CheckPinDown(pin);
            }
        }
        public void CheckPinDown(Transform pin)
        {

            float angle = Vector3.Angle(pin.up, Vector3.up);

            if (angle > 5f && pin.gameObject.activeSelf)
            {
                pin.gameObject.SetActive(false);
                numberOfPinsHitDown++;
            }
        }

        public int GetNumberOfPinsHitDown()
        {
            CheckPinsDown();
            return numberOfPinsHitDown;
        }
    }
}

