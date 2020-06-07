using System;
using FLFlight;
using UnityEngine;

[CreateAssetMenu(fileName = "ControlShipEventAction", menuName = "Events/ControlShipAction", order = 0)]
public class ControlShipEvent : EventAction
{
    public override void Action(GameObject triggeredObject)
    {
        PlayerMovement pm = FindObjectOfType<PlayerMovement>();
        MouseLook ml = FindObjectOfType<MouseLook>();
        ShipInput si = FindObjectOfType<ShipInput>();
        GameObject HUD = GameObject.Find("HUD");

        if (!pm.isFlyingShip)
        {
            HUD.GetComponent<Canvas>().enabled = true;
            Cursor.lockState = CursorLockMode.None;
            pm.GetComponent<Rigidbody>().useGravity = false;
            pm.GetComponent<Rigidbody>().isKinematic = true;
            pm.isFlyingShip = true;
            ml.isFlyingShip = true;
            si.enabled = true;
            
        }
        else
        {
            HUD.GetComponent<Canvas>().enabled = false;
            Cursor.lockState = CursorLockMode.Locked;
            pm.isFlyingShip = false;
            ml.isFlyingShip = false;
            si.enabled = false;
        }
    }

    public override string KeyToTriggerText()
    {
        return $"Press {_keyToTrigger.ToString()} to control the ship";
    }
}