using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Repair : MonoBehaviour
{
    public static TextMeshProUGUI _repairPitchText;
    public static TextMeshProUGUI _repairRollText;
    public static TextMeshProUGUI _repairThrottleText;
    public static TextMeshProUGUI _repairYawText;

    private void Start()
    {
        _repairPitchText = transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        _repairRollText = transform.GetChild(2).GetComponent<TextMeshProUGUI>();
        _repairThrottleText = transform.GetChild(3).GetComponent<TextMeshProUGUI>();
        _repairYawText = transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        
        _repairPitchText.gameObject.SetActive(false);
        _repairRollText.gameObject.SetActive(false);
        _repairThrottleText.gameObject.SetActive(false);
        _repairYawText.gameObject.SetActive(false);
    }

    public static void AnnounceNeedsRepair(Module.ShipModule shipModule)
    {
        switch (shipModule)
        {
            case Module.ShipModule.Throttle:
                _repairThrottleText.gameObject.SetActive(true);
                break;
            case Module.ShipModule.Strafe:
                //_repairThrottleText.gameObject.SetActive(true);
                break;
            case Module.ShipModule.Roll:
                _repairRollText.gameObject.SetActive(true);
                break;
            case Module.ShipModule.Yaw:
                _repairYawText.gameObject.SetActive(true);
                break;
            case Module.ShipModule.Pitch:
                _repairPitchText.gameObject.SetActive(true);
                break;
        }
    }

    public static void AnnounceRepaired(Module.ShipModule shipModule)
    {
        switch (shipModule)
        {
            case Module.ShipModule.Throttle:
                _repairThrottleText.gameObject.SetActive(false);
                break;
            case Module.ShipModule.Strafe:
                //_repairThrottleText.gameObject.SetActive(true);
                break;
            case Module.ShipModule.Roll:
                _repairRollText.gameObject.SetActive(false);
                break;
            case Module.ShipModule.Yaw:
                _repairYawText.gameObject.SetActive(false);
                break;
            case Module.ShipModule.Pitch:
                _repairPitchText.gameObject.SetActive(false);
                break;
        }
    }
}
