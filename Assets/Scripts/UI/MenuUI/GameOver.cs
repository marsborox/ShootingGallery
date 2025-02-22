using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI score;

    void Start()
    {
        score.text = FindObjectOfType<Score>().playerScore.ToString();
    }

}
