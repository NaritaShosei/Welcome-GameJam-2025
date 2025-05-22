using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    // Playerに当たるまでの時間（秒）
    [SerializeField] float TimePeriodToHit = default;
    // 当たるときの拡大倍率【参考値:3】
    [SerializeField] float ScaleToHit = default;
    // フレーム毎の設定用拡大倍率
    float ZoomScale = default;
    // 生成されてからの経過時間
    float TimePast = default;
    // 弾の移動速度
    Vector2 BulletVelocity = default;

    // 画面中央

    PlayerHP _player;

    void Start()
    {
        TimePast = 0;
        ZoomScale = 1f;

        var random = Random.Range(0, 3);

        Color color = random switch
        {
            0 => Color.red,
            1 => Color.green,
            2 => Color.blue,
        };

        GetComponent<ConflictColorSystem>().ColorChange(color);

        // ランダムで速度を付与する
        float bulletX = Random.Range(-1f, 1f);
        float bulletY = Random.Range(-1f, 1f);
        BulletVelocity = new Vector2(bulletX, bulletY);
        gameObject.GetComponent<Rigidbody2D>().velocity = BulletVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        TimePast += Time.deltaTime;

        // 拡大倍率を算出する
        ZoomScale = 1f + (ScaleToHit * TimePast / TimePeriodToHit);
        transform.localScale = new Vector2(ZoomScale, ZoomScale);

        // 経過時間が当たる時間より大きい場合、Playerにダメージ
        if (TimePast > TimePeriodToHit)
        {
            DoDamageToPlayer();
        }

        Vector2 pos = transform.position;

        pos.x = Mathf.Clamp(pos.x, -8, 8);
        pos.y = Mathf.Clamp(pos.y, -4, 4);

        transform.position = pos;
    }

    // プレイヤーダメージ処理
    void DoDamageToPlayer()
    {
        _player.AddDamage();
        Destroy(this.gameObject);
        // UIにエフェクトをかける
    }
    public void GetPlayer(PlayerHP player)
    {
        _player = player;
    }
}
