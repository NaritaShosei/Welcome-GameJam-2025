using UnityEngine;

public class ChatGPT : MonoBehaviour
{
    public float speed = 2f;
    public float amplitude = 10f; // ”g‚ÌU•
    public float frequency = 5f; // ”g‚Ìü”g”

    private float startTime;

    void Start()
    {
        startTime = Time.time;

    }

    void Update()
    {
        float x = Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - startTime)) * amplitude;
        transform.position = new Vector2(x, transform.position.y);
    }
}
