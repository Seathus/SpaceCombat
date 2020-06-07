using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public List<EventTriggerable> _triggerables;
    public TextMeshProUGUI _KeyToTriggerText;
    private EventTriggerable _availableTrigger;
    
    private void Update()
    {
        int nearCount = 0;
        float nearestDistance = 1000;
        foreach (EventTriggerable _triggerable in _triggerables)
        {
            float distance = Vector3.Distance(_triggerable.gameObject.transform.position, transform.position);

            if (distance < nearestDistance && distance < 2.0f)
            {
                nearCount++;
                nearestDistance = distance;
                _availableTrigger = _triggerable;
                ShowKeyToTrigger(_triggerable);
            }
        }

        if (nearCount == 0)
        {
            ClearTriggerText();
        }
        else
        {
            if (Input.GetKeyDown(_availableTrigger._eventToTrigger._keyToTrigger))
            {
                Debug.Log("Trigger");
                _availableTrigger._event.Invoke();
            }
        }
        
        
    }

    void ShowKeyToTrigger(EventTriggerable _triggerable)
    {
        _KeyToTriggerText.text = _triggerable._eventToTrigger.KeyToTriggerText();
    }

    void ClearTriggerText()
    {
        _KeyToTriggerText.text = string.Empty;
    }
}
