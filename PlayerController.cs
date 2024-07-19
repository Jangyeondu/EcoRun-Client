using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 2f; // 점프 높이
    public float jumpDuration = 0.5f; // 점프 시간
    public Sprite jumpSprite; // 점프할 때 사용할 스프라이트
    private Sprite defaultSprite; // 기본 스프라이트
    private Vector3 startPosition;
    private bool isJumping = false;
    private float jumpTimer;
    private SpriteRenderer spriteRenderer;
    private ScoreManager scoreManager; // 점수를 관리하는 스크립트

    void Start()
    {
        startPosition = transform.position; // 시작 위치 저장
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer 컴포넌트를 가져옴
        defaultSprite = spriteRenderer.sprite; // 기본 스프라이트 저장

        scoreManager = FindObjectOfType<ScoreManager>(); // ScoreManager를 찾음
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            Jump();
        }

        if (isJumping)
        {
            // 점프 시간 경과에 따른 캐릭터 위치 업데이트
            jumpTimer += Time.deltaTime;
            float t = jumpTimer / jumpDuration;

            if (t < 0.5f)
            {
                // 위로 이동
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * jumpHeight, t * 2);
            }
            else
            {
                // 아래로 이동
                transform.position = Vector3.Lerp(startPosition + Vector3.up * jumpHeight, startPosition, (t - 0.5f) * 2);
            }

            if (jumpTimer >= jumpDuration)
            {
                // 점프 종료
                transform.position = startPosition;
                isJumping = false;
                jumpTimer = 0f; // 타이머 초기화
                spriteRenderer.sprite = defaultSprite; // 기본 스프라이트로 되돌리기
            }
        }
    }

    void Jump()
    {
        isJumping = true;
        jumpTimer = 0f; // 점프 시작 시 타이머 초기화
        spriteRenderer.sprite = jumpSprite; // 점프 스프라이트로 변경
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            scoreManager.IncreaseScore(); // 점수 증가
            Destroy(other.gameObject); // 코인 제거
        }
    }
}
