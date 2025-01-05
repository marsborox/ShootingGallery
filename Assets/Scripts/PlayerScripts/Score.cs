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
    }
    void Start()
    {
        
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AddScore(int addScore)
    {
        playerScore=playerScore + addScore;
    }
    private void OnEnable()
    {
        OnDeath += ScoreAdded;
    }
    private void OnDisable()
    {
        
    }
    void ScoreAdded()
    {
        uIDisplay.SetScoretext(playerScore);//refresh score on UI
    }
}
