using UnityEngine;

[CreateAssetMenu(fileName = "EventAction", menuName = "Events/Action", order = 0)]
public abstract class EventAction : ScriptableObject
{
    public KeyCode _keyToTrigger;
    public abstract void Action(GameObject triggeredObject);

    public abstract string KeyToTriggerText();
}