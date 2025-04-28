using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollLeft : MonoBehaviour
{
    public float moveSpeed = 5f; // 이동 속도

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -10f) // 화면 왼쪽 끝에서 제거
        {
            Destroy(gameObject);
        }
    }
}
