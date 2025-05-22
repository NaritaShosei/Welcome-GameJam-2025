using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleUpOnSpawn : MonoBehaviour
{
    public float duration = 0.5f; // Šg‘å‚·‚é‚Ü‚Å‚ÌŠÔ
    private Vector3 targetScale;
    private float timer = 0f;

    void Start()
    {
        targetScale = transform.localScale;
        transform.localScale = Vector3.zero; // Å‰‚Íƒ[ƒƒTƒCƒY
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