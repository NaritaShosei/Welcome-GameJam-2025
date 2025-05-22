using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    // Playerに当たるまでの時間
    [SerializeField] float TimePeriodToHit = default;
    // 当たるときの拡大倍率
    [SerializeField] float ScaleToHit = default;
    GameObject player = default;
    // フレーム毎の拡大倍率の増える量
    float ZoomScaleCountUp = default;
    float ZoomScale = default;
    // 生成されてからの経過時間
    float TimePast = default;
    // 弾の移動速度
    Vector2 BulletVelocity = default;
    // 弾の色
    public int Color = default;

    void Start()
    {
        TimePast = 0;
        ZoomScaleCountUp = ScaleToHit / (TimePeriodToHit * (1f / Time.deltaTime)) / 2;
        ZoomScale = 1f;
        Debug.Log("弾の色:" + Color);
        float bulletX = Random.Range(-1.5f, 1.5f);
        float bulletY = Random.Range(-1.5f, 1.5f);
        BulletVelocity = new Vector2(bulletX, bulletY);
        gameObject.GetComponent<Rigidbody2D>().velocity = BulletVelocity;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // 拡大倍率を算出する
        ZoomScale = 1f + (ScaleToHit * TimePast / TimePeriodToHit);
        transform.localScale = (Vector3) new Vector2(ZoomScale, ZoomScale);

        TimePast += Time.deltaTime;
        // 経過時間が当たる時間より大きい場合、Playerにダメージ
        if (TimePast > TimePeriodToHit)
        {
            DoDamageToPlayer();
        }
    }

    void DoDamageToPlayer()
    {
        Debug.Log("弾がPlayerにダメージ");

        Destroy(this.gameObject);
        // UIにエフェクトをかける
    }
}
