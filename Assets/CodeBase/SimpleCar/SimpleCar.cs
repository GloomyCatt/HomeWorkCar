using System;
using System.Linq;
using UnityEngine;

namespace Car
{
    public enum TypeOfActuators
    {
        FWD,
        RWD,
        AWD
    }

    public class SimpleCar : MonoBehaviour
    {
        [Header("CarParams")]
        [SerializeField]
        private float maxSteer = 45f;
        [SerializeField] private float power = 10f;
        [Header("Wheels")]
        [SerializeField] private TypeOfActuators actuators = TypeOfActuators.FWD;
        [SerializeField]
        private Wheel[] steerWheels = Array.Empty<Wheel>();
        [SerializeField]
        private Wheel[] powerWheels = Array.Empty<Wheel>();
   
        private void Update()
        {
            Turning();
            Powering();
        }

        private void Turning()
        {
            foreach (var wheelCollider in steerWheels)
            {
                wheelCollider.Steer(
                    Input.GetAxis("Horizontal")
                    * maxSteer 
                );
            }
        }

        private void Powering()
        {
            foreach (var powerWheel in ReturnPoweringWheels())
            {
                powerWheel.Torque(
                    Input.GetAxis("Vertical")
                    * power
                    * Time.deltaTime
                );
            }
        }

        private Wheel[] ReturnPoweringWheels()
        {
            switch (actuators)
            {
                case TypeOfActuators.FWD:
                    return steerWheels;                   
                case TypeOfActuators.RWD: 
                    return powerWheels;
                case TypeOfActuators.AWD:
                    return powerWheels.Concat(steerWheels).ToArray();
            }
            return null;
        }
    }
}
