using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject EnemyBullet = default;
    [SerializeField] GameObject EnemyAttack2Ring = default;
    int Damage = 1;
    // çUåÇä‘äu(ïb)
    [SerializeField]  float AttackInterval = 5f;
    // çUåÇÇQÇÃägëÂî{ó¶
    [SerializeField] float Attack2Scale = default;
    // çUåÇÇQÇÃââèoéûä‘(ïb)
    [SerializeField] float Attack2TimePeriod = default;
    // ägëÂë¨ìx
    [SerializeField] float Attack2ScaleSpeed = default;

    float AttackCooldown = default;
    int Color = default;
    [SerializeField] bool DebugSwitch = default;
    bool InAttack2 = default;
    bool Attack2Arriving = default;
    bool Attack2Hit = default;
    float ZoomScale = default;

    void Start()
    {
        Color = Random.Range(1, 4);
        Debug.Log("ìGê∂ê¨ÅBêFÅF" + Color);
        AttackCooldown = AttackInterval;
        InAttack2 = false;
        Attack2Arriving = false;
        Attack2Hit = false;
        ZoomScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (DebugSwitch)
        {
            // DEBUGóp
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
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DoAttack1();
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PrepareAttack2();
            }
        } else {
            AttackCooldown -= Time.deltaTime;

            if (AttackCooldown <= 0)
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
        }
        if (InAttack2)
        {
            DoAttack2();
        }
    }
    // ìGçUåÇÇPÅFíeÇåÇÇ¬
    void DoAttack1()
    {
        Debug.Log("çUåÇÇPî≠ìÆ");
        GameObject enemyBullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBulletBehaviour>().Color = this.Color;
        AttackCooldown = AttackInterval;
    }

    // ìGçUåÇÇQÅFó\îıìÆçÏ
    void PrepareAttack2()
    {
        Debug.Log("çUåÇÇQópà”äJén");
        GameObject attackRing = Instantiate(EnemyAttack2Ring, transform.position, Quaternion.identity, transform);
    }

    // ìGçUåÇÇQÅFëÃìñÇΩÇË
    public void StartAttack2()
    {
        InAttack2 = true;
        Attack2Arriving = true;
    }

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
            if (ZoomScale <= 1f)
            {
                transform.localScale = new Vector2(1f, 1f);
                Attack2Hit = false;
                InAttack2 = false;
            }
        }
    }
    void DoDamageToPlayer()
    {
        Debug.Log("çUåÇÇQÇ™PlayerÇ…É_ÉÅÅ[ÉW");
        // UIÇ…ÉGÉtÉFÉNÉgÇÇ©ÇØÇÈ
    }
}
