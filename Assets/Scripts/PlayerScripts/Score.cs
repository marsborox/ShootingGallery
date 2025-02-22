using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Target;

public class Score : MonoBehaviour
{
    public int playerScore;
    [SerializeField] GameObject ui;
    UIDisplay uIDisplay;
    public event Action OnDeath;
    // Start is called before the first frame update
    
    private void Awake()
    {
        uIDisplay = ui.GetComponent<UIDisplay>();
        ManageSingleton();
    }
    void Start()
    {
        playerScore = 0;
    }
    

    // Update is called once per frame
    void Update()
    {
        
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
