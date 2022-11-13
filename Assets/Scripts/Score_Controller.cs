using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score_Controller : MonoBehaviour
{
    private TextMeshProUGUI ScoreText;
    private int Score = 0;

    private void Awake()
    {
        ScoreText = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        RefreshUI();
    }

    public void IncreaseScore(int Increament)
    {
        Score += Increament;
        RefreshUI();
    }

    private void RefreshUI()
    {
        ScoreText.text = Score + "";
    }
}
