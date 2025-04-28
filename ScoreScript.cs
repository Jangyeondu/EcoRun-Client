using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreScript : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // 점수를 표시할 UI 텍스트
    public int score = 0; // 현재 점수
    public static int enemy = 0;
    private float length = 0f;

    void Start()
    {
        UpdateScoreText(); // 시작할 때 점수 텍스트를 초기화합니다.
    }

    void Update()
    {
        length += Time.deltaTime + 0.5f;
        UpdateScoreText();
    }

    public void IncreaseScore()
    {
        score++; // 점수를 1 증가시킵니다.

        if (score == 50)
        {
            Application.Quit();
        }
    }   

    public void DecreaseScore()
    {
        enemy++;

        HeartScript.RemoveHeart(enemy);

        if (enemy == 4)
        {
            Application.Quit();
            Debug.Log("quit");
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = ((int)length).ToString() + "m"; // 점수를 UI에 표시합니다.
    }
}
