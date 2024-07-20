using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Coin : MonoBehaviour
{
    private float moveSpeed;
    private float destroyX;

    public float scrollSpeed = 1f;    // 배경 이동 속도

    public void Initialize(float moveSpeed, float destroyX)
    {
        this.moveSpeed = moveSpeed;
        this.destroyX = destroyX;
    }

    void Update()
    {
        transform.Translate(Vector3.left * scrollSpeed * Time.deltaTime);
    }
}

