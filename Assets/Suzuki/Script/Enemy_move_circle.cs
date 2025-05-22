using UnityEngine;

public class Enemy_move : MonoBehaviour
{
    [SerializeField] int speed;                //オブジェクトのスピード
    [SerializeField] int radius;               //円を描く半径
    private Vector2 defPosition;      //defPositionをVector2で定義する。
    float x;
    float y;

    // Use this for initialization
    void Start()
    {
        
        

        defPosition = transform.position;    //defPositionを自分のいる位置に設定する。
    }

    // Update is called once per frame
    void Update()
    {
        x = radius * Mathf.Sin(Time.time * speed);      //X軸の設定
        y = radius * Mathf.Cos(Time.time * speed);      //y軸の設定

        transform.position = new Vector2(x + defPosition.x, y+defPosition.y);  //自分のいる位置から座標を動かす。



    }
}