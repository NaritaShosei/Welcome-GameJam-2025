using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2RingBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    // Playerにダメージまでの時間（秒）
    [SerializeField] float TimePeriodToDamage = default;
    // 初期拡大倍率【参考値:5】
    [SerializeField] float InitScale = default;
    // ダメージ時の拡大倍率【参考値:0】
    [SerializeField] float HitScale = default;
    // フレーム毎の拡大倍率の増える量
    float ZoomScale = default;
    // 生成されてからの経過時間
    float TimePast = default;
    void Start()
    {
        Debug.Log("攻撃２準備Ring生成.");
        ZoomScale = InitScale;
        TimePast = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // 処理の拡大倍率から0まで縮小する
        transform.localScale = new Vector2(ZoomScale, ZoomScale);
        TimePast += Time.deltaTime;
        ZoomScale = InitScale * (1 - (TimePast / TimePeriodToDamage));

        // マイナス値になることを防止
        if(ZoomScale < 0f)
        {
            ZoomScale = 0f;
        }

        // ダメージ時間に達すると、攻撃２演出を開始し、自身を消す
        if(TimePast > TimePeriodToDamage)
        {
            Debug.Log("Ring消滅、攻撃２実施");
            GetComponentInParent<EnemyAttack>().StartAttack2();
            Destroy(gameObject);
        }
    }
}
