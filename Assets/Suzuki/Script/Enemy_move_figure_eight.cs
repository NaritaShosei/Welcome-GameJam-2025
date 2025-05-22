using UnityEngine;

public class Enemy_move_figure_eight : MonoBehaviour
{
    public float speed = 2f;       // �ړ����x
    public float radius = 2f;      // ���̎��̔��a
    private float time;

    void Update()
    {
        time += Time.deltaTime * speed; // ���Ԃ�i�߂�

        // ���̎��̌v�Z (2D)
        float x = radius * Mathf.Sin(time); // x���W
        float y = radius * Mathf.Sin(time * 2); // y���W

        // �V�����ʒu��ݒ� (Vector2)
        transform.position = new Vector3(x, y/2, 0f);
    }
}
