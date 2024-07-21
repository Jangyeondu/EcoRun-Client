using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight = 2f; // ���� ����
    public float jumpDuration = 0.5f; // ���� �ð�
    public float slideDuration = 1f; // �����̵� �ð�

    public Sprite jumpSprite; // ������ �� ����� ��������Ʈ
    public Sprite slideSprite; // �����̵��� �� ����� ��������Ʈ
    public Sprite defaultSprite; // �⺻ ��������Ʈ

    private Vector3 startPosition;
    private bool isJumping = false;
    private bool isSliding = false;
    private float jumpTimer;
    private SpriteRenderer spriteRenderer;
    private ScoreManager scoreManager; // ������ �����ϴ� ��ũ��Ʈ

    private Coroutine resetSpriteCoroutine;

    void Start()
    {
        startPosition = transform.position; // ���� ��ġ ����
        spriteRenderer = GetComponent<SpriteRenderer>(); // SpriteRenderer ������Ʈ�� ������
        defaultSprite = spriteRenderer.sprite; // �⺻ ��������Ʈ ����

        scoreManager = FindObjectOfType<ScoreManager>(); // ScoreManager�� ã��
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping && !isSliding)
        {
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && !isSliding && !isJumping)
        {
            Slide();
        }

        if (isJumping)
        {
            // ���� �ð� ����� ���� ĳ���� ��ġ ������Ʈ
            jumpTimer += Time.deltaTime;
            float t = jumpTimer / jumpDuration;

            if (t < 0.5f)
            {
                // ���� �̵�
                transform.position = Vector3.Lerp(startPosition, startPosition + Vector3.up * jumpHeight, t * 2);
            }
            else
            {
                // �Ʒ��� �̵�
                transform.position = Vector3.Lerp(startPosition + Vector3.up * jumpHeight, startPosition, (t - 0.5f) * 2);
            }

            if (jumpTimer >= jumpDuration)
            {
                // ���� ����
                transform.position = startPosition;
                isJumping = false;
                jumpTimer = 0f; // Ÿ�̸� �ʱ�ȭ
                spriteRenderer.sprite = defaultSprite; // �⺻ ��������Ʈ�� �ǵ�����
            }
        }
    }

    IEnumerator ResetSpriteAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.sprite = defaultSprite;
        isSliding = false; // �����̵� ���� ����
    }

    void Jump()
    {
        isJumping = true;
        jumpTimer = 0f; // ���� ���� �� Ÿ�̸� �ʱ�ȭ
        spriteRenderer.sprite = jumpSprite; // ���� ��������Ʈ�� ����
    }

    void Slide()
    {
        isSliding = true;
        spriteRenderer.sprite = slideSprite; // �����̵� ��������Ʈ�� ����

        // �����̵尡 ������ �⺻ ��������Ʈ�� �ǵ����� Coroutine ����
        if (resetSpriteCoroutine != null)
        {
            StopCoroutine(resetSpriteCoroutine);
        }
        resetSpriteCoroutine = StartCoroutine(ResetSpriteAfterDelay(slideDuration));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            scoreManager.IncreaseScore(); // ���� ����
            Destroy(other.gameObject); // ���� ����
        }
        else if (other.CompareTag("Enemy"))
        {
            scoreManager.DecreaseScore();
            Destroy(other.gameObject);
        }
    }
}
