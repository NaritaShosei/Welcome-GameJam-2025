using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private int _index;
    [SerializeField] float speed; //敵のスピード
    [SerializeField] Vector2[] _positions; //移動する位置

    void Update()
    {
        var dir = ((Vector3)_positions[_index] - transform.position).normalized;//vector３の型に変換して現在位置を取得してノーマライズする
        transform.position += dir * speed * Time.deltaTime;//speedとデルタタイムとdirをかけた数値分移動する

        if (Vector2.Distance(_positions[_index], transform.position) <= 0.3f)//現在の位置が0.3f以下なら
        {
            _index = (_index + 1) % _positions.Length;//次の移動位置を変更し、最後の位置なら元の位置に戻る
        }

    }


}
