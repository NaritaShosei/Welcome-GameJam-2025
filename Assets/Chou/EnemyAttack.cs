using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // 攻撃１の弾Prefab
    [SerializeField] GameObject EnemyBullet = default;
    // 攻撃２の準備の「輪」Prefab
    [SerializeField] GameObject EnemyAttack2Ring = default;
    // 攻撃間隔(秒)
    [SerializeField]  float AttackInterval = 5f;
    // 攻撃２演出の拡大速度【参考値:0.04】
    [SerializeField] float Attack2ScaleSpeed = default;
    // 攻撃２演出の最終拡大倍率【参考値:2】
    [SerializeField] float Attack2Scale = default;

    // 攻撃クールダウン
    float AttackCooldown = default;
    // 敵の色
    int Color = default;
    // 状態フラグ：攻撃２演出中
    bool InAttack2 = default;
    // 状態フラグ：攻撃２演出拡大中
    bool Attack2Arriving = default;
    // 状態フラグ：攻撃２演出戻り中
    bool Attack2Hit = default;
    // フレーム毎の拡大倍率
    float ZoomScale = default;
    // 初期拡大倍率
    float InitZoomScale = default;

    // debug用
    [SerializeField] bool DebugSwitch = default;

    void Start()
    {
        Color = Random.Range(1, 4);
        Debug.Log("敵生成。色：" + Color);
        AttackCooldown = AttackInterval;
        InAttack2 = false;
        Attack2Arriving = false;
        Attack2Hit = false;
        InitZoomScale = transform.localScale.x;
        ZoomScale = InitZoomScale;
    }

    void Update()
    {
        if (DebugSwitch)
        {
            // DEBUG用：スペースキーで攻撃をランダムで行う
            if (Input.GetKeyDown(KeyCode.Space))
            {
                int attackNum = Random.Range(1, 3);
                if (attackNum == 1)
                {
                    DoAttack1();
                }
                else
                {
                    PrepareAttack2();
                }
            }
            // DEBUG用：数字キー「1」で攻撃１を行う
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DoAttack1();
            }
            // DEBUG用：数字キー「2」で攻撃２を行う
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PrepareAttack2();
            }
        } else {
            AttackCooldown -= Time.deltaTime;

            if (AttackCooldown <= 0)
            {
                // 攻撃可能になると、攻撃１か２をランダムでする
                int attackNum = Random.Range(1, 3);
                if (attackNum == 1)
                {
                    DoAttack1();
                }
                else
                {
                    PrepareAttack2();
                }
                // 攻撃クールダウンをリセット
                AttackCooldown = AttackInterval;
            }
        }
        // 攻撃２演出中の処理
        if (InAttack2)
        {
            DoAttack2();
        }
    }

    // 敵攻撃１：弾を撃つ
    void DoAttack1()
    {
        Debug.Log("攻撃１発動");
        GameObject enemyBullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBulletBehaviour>().Color = this.Color;
        AttackCooldown = AttackInterval;
    }

    // 敵攻撃２：予備動作
    void PrepareAttack2()
    {
        Debug.Log("攻撃２用意開始");
        GameObject attackRing = Instantiate(EnemyAttack2Ring, transform.position, Quaternion.identity, transform);
    }

    // 敵攻撃２：攻撃開始
    public void StartAttack2()
    {
        InAttack2 = true;
        Attack2Arriving = true;
    }

    // 敵攻撃２：攻撃演出
    void DoAttack2()
    {
        if (Attack2Arriving)
        {
            ZoomScale = ZoomScale + Attack2ScaleSpeed;
            transform.localScale = new Vector2(ZoomScale, ZoomScale);
            if(ZoomScale >= Attack2Scale)
            {
                DoDamageToPlayer();
                Attack2Arriving = false;
                Attack2Hit = true;
            }
        } else if (Attack2Hit)
        {
            ZoomScale = ZoomScale - Attack2ScaleSpeed;
            transform.localScale = new Vector2(ZoomScale, ZoomScale);
            if (ZoomScale <= InitZoomScale)
            {
                transform.localScale = new Vector2(InitZoomScale, InitZoomScale);
                Attack2Hit = false;
                InAttack2 = false;
            }
        }
    }
    // プレイヤーダメージ処理
    void DoDamageToPlayer()
    {
        Debug.Log("攻撃２がPlayerにダメージ");
        // UIにエフェクトをかける
    }
}
