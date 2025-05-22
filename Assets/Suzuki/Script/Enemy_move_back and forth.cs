using UnityEngine;

public class ChatGPT : MonoBehaviour
{


    [SerializeField] float _range = 2f;
    [SerializeField] float _duration = 2;
    //public float amplitude = 10f; // 波の振幅
    //public float frequency = 5f; // 波の周波数
    float _offsetY;
    //private float startTime;

    void Start()
    {
        //startTime = Time.time;
        _offsetY = Random.Range(-2.53f, 4);

    }

    void Update()
    {
        //float x = Mathf.Sin(2 * Mathf.PI * frequency * (Time.time - startTime)) * amplitude;
        //transform.position = new Vector2(x, transform.position.y);
        var sin = Mathf.Sin(Time.time / _duration);
        transform.position = new Vector2(sin * _range, _offsetY);
    }
}
