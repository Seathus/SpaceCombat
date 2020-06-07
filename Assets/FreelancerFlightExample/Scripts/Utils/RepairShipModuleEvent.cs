using UnityEngine;

[CreateAssetMenu(fileName = "RepairShipModuleEventAction", menuName = "Events/RepairShipModuleAction", order = 0)]
public class RepairShipModuleEvent : EventAction
{
    public override void Action(GameObject triggeredObject)
    {
        Debug.Log("Reparing.. " + triggeredObject.gameObject.name);
        triggeredObject.GetComponent<Module>().isFunctional = true;
    }

    public override string KeyToTriggerText()
    {
        return $"Press {_keyToTrigger.ToString()} to repair this module";
    }
}