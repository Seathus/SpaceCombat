using System;
using FLFlight;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlShipEventAction", menuName = "Events/ControlShipAction", order = 0)]
public class ControlShipEvent : EventAction
{
    public override void Action()
    {
        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        MouseLook ml = FindObjectOfType<MouseLook>();
        ShipInput si = FindObjectOfType<ShipInput>();

        if (!pm.isFlyingShip)
        {
            Cursor.lockState = CursorLockMode.None;
            pm.GetComponent<Rigidbody>().useGravity = false;
            pm.GetComponent<Rigidbody>().isKinematic = true;
            pm.isFlyingShip = true;
            ml.isFlyingShip = true;
            si.enabled = true;
            
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            pm.isFlyingShip = false;
            ml.isFlyingShip = false;
            si.enabled = false;
        }
    }
}