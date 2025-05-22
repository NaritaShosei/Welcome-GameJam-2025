using System.Collections.Generic;
using UnityEngine;



public class Enemy_warp : MonoBehaviour
{
    float timer;
    [SerializeField] float _interval = 1;//ワープのクールタイム
    [SerializeField] Vector2[] _positions;
    void Start()
    {

    }
    private void Update()
    {
        var index = Random.Range(0, _positions.Length);　// ※ 設定したワープポジション数の範囲でランダムな整数値が返る
        timer += Time.deltaTime;//timerにTime.deltaTimeを加算する
        if (timer >= _interval) //timerがインターバル以上なら
        {
            transform.position= _positions[index];//ポジションを移動
            timer = 0;//timerをリセット
        }
    }
}