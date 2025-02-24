using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using static Target;

public class Score : MonoBehaviour
{
    public int playerScore;
    
    UIDisplay uIDisplay;
    public event Action OnDeath;
    
    // Start is called before the first frame update
    
    private void Awake()
    {
        ManageSingleton();
    }
   

    // Update is called once per frame

    public void ResetScoreScript()
    {
        uIDisplay = FindObjectOfType<UIDisplay>();
        playerScore = 0;
    }
    public void AddScore(int addScore)
    {
        playerScore=playerScore + addScore;
        uIDisplay.SetScoretext(playerScore);
    }
    void ManageSingleton()
    {//it will track of how many instances of audio player exist

        int instanceCount = FindObjectsOfType(GetType()).Length;
        if (instanceCount > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

}
