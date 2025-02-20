using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class UITimer : MonoBehaviour
{
    [SerializeField] Timer timer;
    [SerializeField]TextMeshProUGUI timeRemainingText;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    void Update()
    {
        DisplayTime();
    }
    void DisplayTime()
    {
        int displayTimeInt;
        displayTimeInt = (int)timer.timeRemaining;
        TimeSpan time = TimeSpan.FromSeconds(displayTimeInt);
        timeRemainingText.text = time.ToString().Substring(3);
    }
}
