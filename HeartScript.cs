using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public static GameObject[] heartObjects; // 다수의 하트 오브젝트를 배열로 관리

    void Start()
    {
        // 하트 오브젝트들을 배열에 할당
        heartObjects = GameObject.FindGameObjectsWithTag("Heart");
    }

    public static void RemoveHeart(int count)
    {
        if (count >= 0 && count < heartObjects.Length && heartObjects[count] != null)
        {
            Destroy(heartObjects[count]);
            heartObjects[count] = null; // Destroy된 오브젝트를 배열에서 제거
        }
    }
}
