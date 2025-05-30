using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpOnSpawn : MonoBehaviour
{
    public float duration = 0.5f; // 拡大するまでの時間
    private Vector3 targetScale;
    private float timer = 0f;

    void Start()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero; // 最初はゼロサイズ
    }

    void Update()
    {
        if (timer < duration)
        {
            timer += Time.deltaTime;
            float t = timer / duration;
            transform.localScale = Vector3.Lerp(Vector3.zero, targetScale, t);
        }
    }
}