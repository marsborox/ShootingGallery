using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Time.timeScale = 1f;
    }
    void FlowOfTime()
    { 
        timeRemaining=timeRemaining-Time.deltaTime;

        if (timeRemaining <= 0)
        {
            gameGoing = false;
            Debug.Log("timer.Game Over");
            SceneManager.LoadScene("GameOver");
        }
    }


}
