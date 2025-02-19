using System.Collections;
using System.Collections.Generic;

using Unity.VisualScripting;

using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float startTimeMax;
    public float timeRemaining;
    bool gameGoing = true;
    void Start()
    {
        ResetTimer();
    }
    void Update()
    {
        if (gameGoing)
        {
            FlowOfTime();
        }
    }

    void ResetTimer()
    {
        timeRemaining = startTimeMax;
    }
    void FlowOfTime()
    { 
        timeRemaining=timeRemaining-Time.deltaTime;

        if (timeRemaining <= 0)
        {
            gameGoing = false;
            Debug.Log("timer.Game Over");
            
        }
    }


}
