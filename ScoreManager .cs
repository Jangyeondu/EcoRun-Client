using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // ������ ǥ���� UI �ؽ�Ʈ
    private int score = 0; // ���� ����

    void Start()
    {
        UpdateScoreText(); // ������ �� ���� �ؽ�Ʈ�� �ʱ�ȭ�մϴ�.
    }

    public void IncreaseScore()
    {
        score++; // ������ 1 ������ŵ�ϴ�.
        UpdateScoreText(); // ���� �ؽ�Ʈ�� ������Ʈ�մϴ�.
    }   

    public void DecreaseScore()
    {
        score--;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score; // ������ UI�� ǥ���մϴ�.
    }
}
