using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    
    


    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = "0";
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
