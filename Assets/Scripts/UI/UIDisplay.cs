using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    public TextMeshProUGUI scoreText { private get; set; }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetScoretext(int inputScore)
    { 
        scoreText.text=inputScore.ToString();
    }
}
