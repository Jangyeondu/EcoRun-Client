using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트
    private int score = 0; // 현재 점수

    void Start()
    {
        UpdateScoreText(); // 시작할 때 점수 텍스트를 초기화합니다.
    }

    public void IncreaseScore()
    {
        score++; // 점수를 1 증가시킵니다.
        UpdateScoreText(); // 점수 텍스트를 업데이트합니다.
        Debug.Log(score);
    }   

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // 점수를 UI에 표시합니다.
    }
}
