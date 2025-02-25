using System;
using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using static Target;

public class Score : Singleton<Score>
{
    public int playerScore;
    
    UIDisplay uIDisplay;
    public event Action OnDeath;

    // Start is called before the first frame update

    protected override void Awake()
    {
        base.Awake();
    }
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
    {
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
