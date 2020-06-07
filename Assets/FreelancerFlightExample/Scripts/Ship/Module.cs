using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Module : MonoBehaviour
{
    public enum ShipModule
    {
        Throttle,
        Strafe,
        Roll,
        Yaw,
        Pitch
    }

    public ShipModule _shipModule;
    public bool isFunctional = true;

    private void Update()
    {
        if (!isFunctional)
        {
            switch (_shipModule)
            {
                case ShipModule.Throttle:
                    FLFlight.Ship.PlayerShip.Input.Throttle = 0;
                    break;
                case ShipModule.Strafe:
                    FLFlight.Ship.PlayerShip.Input.Strafe = 0;
                    break;
                case ShipModule.Roll:
                    FLFlight.Ship.PlayerShip.Input.Roll = 0;
                    break;
                case ShipModule.Yaw:
                    FLFlight.Ship.PlayerShip.Input.Yaw = 0;
                    break;
                case ShipModule.Pitch:
                    FLFlight.Ship.PlayerShip.Input.Pitch = 0;
                    break;
            }
        }
    }
}
