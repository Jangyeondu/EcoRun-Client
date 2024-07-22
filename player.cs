using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rb; // Rigidbody2D를 사용하여 2D 물리 엔진을 사용함

    [SerializeField][Range(100f, 800f)] float jumpForce = 600f; // 점프 힘

    int playerLayer, groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // Rigidbody2D 컴포넌트를 가져옴

        playerLayer = LayerMask.NameToLayer("Player"); // Player 레이어 가져오기
        groundLayer = LayerMask.NameToLayer("Ground"); // Ground 레이어 가져오기
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump")) // 점프 버튼이 눌렸을 때
        {
            if (Mathf.Abs(rb.velocity.y) < 0.01f) // y축 속도가 거의 0일 때 (즉, 땅에 있을 때)
                rb.AddForce(Vector2.up * jumpForce); // 위쪽으로 점프 힘을 추가함
        }

        // 플레이어가 땅에 있을 때 플레이어와 땅의 충돌을 무시하지 않음
        // 플레이어가 공중에 있을 때 플레이어와 땅의 충돌을 무시함
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, false);
        else
            Physics2D.IgnoreLayerCollision(playerLayer, groundLayer, true);
    }
}