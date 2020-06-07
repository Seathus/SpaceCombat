using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkingText : MonoBehaviour
{
    private TextMeshProUGUI _text;

    [Range(-1, 1)] public float currentBlink;
    
    public float timer;

    public float blinkRate = 1;
    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        currentBlink = Mathf.Cos(timer * blinkRate);
        _text.enabled =  currentBlink >= 0;
    }
}
