using System;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace SergeyPchelintsev.Expedito.Controllers.Driving
{
    [RequireComponent(typeof (CarController))]
    public class CarJoystickControl : MonoBehaviour
    {
        private CarController car;
        private VariableJoystick joystick;

        private void Awake()
        {
            car = GetComponent<CarController>();
        }
        
        private void Start()
        {
            joystick = FindObjectOfType<VariableJoystick>();
        }

        private void FixedUpdate()
        {
            var rotatedDegree = (float) Math.Ceiling(transform.rotation.eulerAngles.y);
            var joystickDirection = new Vector3(joystick.Horizontal, joystick.Vertical, 0);
            var rotated = Quaternion.Euler(0, 0, rotatedDegree) * joystickDirection;

            var angle = rotated.normalized.x;
            var torque = rotated.normalized.y;

            var handbrake = 0f;
            
            car.Move(angle, torque, torque, handbrake);
        }
    }
}
