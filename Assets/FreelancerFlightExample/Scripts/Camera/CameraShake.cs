using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CameraShake : MonoBehaviour
{
    private Vector3 originalPos;
    
    public bool shaking;
    // How long the object should shake for.
    public float shakeDuration = 0f;
    // Amplitude of the shake. A larger value shakes the camera harder.
    public float shakeAmount = 0.09f;
    public float decreaseFactor = 1.0f;

    public void LateUpdate()
    {
        if (shaking)
        {
            if (shakeDuration > 0)
            {
                transform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			
                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                shakeDuration = 0f;
                transform.localPosition = originalPos;
                shaking = false;
            }
        }
    }

    public void Shake()
    {
        shaking = true;
        originalPos = transform.localPosition;
        shakeDuration = 0.1f;
    }
}