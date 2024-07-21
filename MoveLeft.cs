using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float moveSpeed = 5f; // �̵� �ӵ�

    void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < -10f) // ȭ�� ���� ������ ����
        {
            Destroy(gameObject);
        }
    }
}
