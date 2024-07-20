using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreText : MonoBehaviour
{
    public Text HighScoreText;

    void Update()
    {
        HighScoreText.text = $"Best Score : {ScoreManager.Instance.highest_M_Points}";
    }
}
