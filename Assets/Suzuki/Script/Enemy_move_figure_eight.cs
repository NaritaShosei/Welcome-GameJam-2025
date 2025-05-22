using UnityEngine;

public class Enemy_move_figure_eight : MonoBehaviour
{
    public float speed = 2f;       // 移動速度
    public float radius = 2f;      // 八の字の半径
    private float time;

    void Update()
    {
        time += Time.deltaTime * speed; // 時間を進める

        // 八の字の計算 (2D)
        float x = radius * Mathf.Sin(time); // x座標
        float y = radius * Mathf.Sin(time * 2); // y座標

        // 新しい位置を設定 (Vector2)
        transform.position = new Vector3(x, y/2, 0f);
    }
}
