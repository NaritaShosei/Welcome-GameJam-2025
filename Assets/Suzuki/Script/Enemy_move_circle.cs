using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    [SerializeField] int speed;                //�I�u�W�F�N�g�̃X�s�[�h
    [SerializeField] int radius;               //�~��`�����a
    private Vector2 defPosition;      //defPosition��Vector2�Œ�`����B
    float x;
    float y;

    // Use this for initialization
    void Start()
    {
        
        

        defPosition = transform.position;    //defPosition�������̂���ʒu�ɐݒ肷��B
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);      //X���̐ݒ�
        y = radius * Mathf.Cos(Time.time * speed);      //y���̐ݒ�

        transform.position = new Vector2(x + defPosition.x, y+defPosition.y);  //�����̂���ʒu������W�𓮂����B



    }
}