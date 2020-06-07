using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<EventTriggerable> _triggerables;
    public TextMeshProUGUI _KeyToTriggerText;
    
    private void Update()
    {
        int nearCount = 0;
        foreach (EventTriggerable _triggerable in _triggerables)
        {
            if (Vector3.Distance(_triggerable.gameObject.transform.position, transform.position) < 2.0f)
            {
                nearCount++;
                ShowKeyToTrigger(_triggerable);
                
                if (Input.GetKeyDown(_triggerable._eventToTrigger._keyToTrigger))
                {
                    Debug.Log("Trigger");
                    _triggerable._event.Invoke();
                }
            }
        }

        if (nearCount == 0)
        {
            ClearTriggerText();
        }
    }

    void ShowKeyToTrigger(EventTriggerable _triggerable)
    {
        _KeyToTriggerText.text = $"Press {_triggerable.GetKeyToTrigger().ToString()} to Interact";
    }

    void ClearTriggerText()
    {
        _KeyToTriggerText.text = string.Empty;
    }
}
