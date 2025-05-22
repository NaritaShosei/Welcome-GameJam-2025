using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float specialGauge = 0f;            // 必殺技ゲージ
    [SerializeField] float gaugeMax = 100f;        // ゲージ最大値
    [SerializeField] float gaugeGain = 5f;        // 1回の攻撃で増える量
    //const float gaugeGainDestroy = 10f;     //敵を倒したときに得る量
    [SerializeField] ColorChanger _colorChanger;
    [SerializeField] SpriteRenderer _sr;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        _sr.color = _colorChanger.Color;

        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        //攻撃を左クリックで発動

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        //必殺技をマウスの中央ボタンで発動

        if (Input.GetMouseButtonDown(2) && specialGauge >= gaugeMax)
        {
            UseSpecialMove();

        }


        // 必殺技ゲージの状態を表示（デバッグ用）
        Debug.Log($"必殺技ゲージ: {specialGauge}/{gaugeMax}");


        //敵を倒すと必殺技がたまる
        //if () 
        {


        }

        void Attack()
        {
            Debug.Log("aaaaaa");
            var ray = Physics2D.Raycast(transform.position, Camera.main.transform.forward, 10);
            if (ray.collider != null && ray.collider.name == "Enemy")
            {

                var target = ray.collider.gameObject.GetComponent<ConflictColorSystem>();
                Debug.Log(target.name);
                if (target.Hit(_colorChanger.Color))
                {
                    // ゲージを増加（最大値を超えないように）
                    specialGauge += gaugeGain;
                    specialGauge = Mathf.Min(specialGauge, gaugeMax);
                }

            }
        }



        void UseSpecialMove()
        {
            Debug.Log("必殺技 発動！！");

            // 敵を全滅させる処理（例：タグが Enemy の全オブジェクトを Destroy）
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }

            // ゲージをリセット
            specialGauge = 0f;
        }
    }
}
