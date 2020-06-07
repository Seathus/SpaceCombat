using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyMode : MonoBehaviour
{
    public bool isActive;
    public Light _emergencyLight;

    public AudioSource _emergencyAudio;
    // Start is called before the first frame update
    void Start()
    {
           
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            _emergencyLight.enabled = true;
        }
        else
        {
            _emergencyLight.enabled = false;
        }
    }

    public void TriggerAudio()
    {
        _emergencyAudio.Play();
    }
    
    

    public void TriggerEmergency()
    {
        if (isActive) return;

        TriggerAudio();
        isActive = true;
    }

    public void CancelEmergency()
    {
        if (!isActive) return;
        
        isActive = false;
        _emergencyAudio.Stop();
    }
}
