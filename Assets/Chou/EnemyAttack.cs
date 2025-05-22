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
    // �U���Ԋu(�b)
    [SerializeField]  float AttackInterval = 5f;
    // �U���Q�̊g��{��
    [SerializeField] float Attack2Scale = default;
    // �U���Q�̉��o����(�b)
    [SerializeField] float Attack2TimePeriod = default;
    // �g�呬�x
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
        Debug.Log("�G�����B�F�F" + Color);
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
            // DEBUG�p
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
    // �G�U���P�F�e������
    void DoAttack1()
    {
        Debug.Log("�U���P����");
        GameObject enemyBullet = Instantiate(EnemyBullet, transform.position, Quaternion.identity);
        enemyBullet.GetComponent<EnemyBulletBehaviour>().Color = this.Color;
        AttackCooldown = AttackInterval;
    }

    // �G�U���Q�F�\������
    void PrepareAttack2()
    {
        Debug.Log("�U���Q�p�ӊJ�n");
        GameObject attackRing = Instantiate(EnemyAttack2Ring, transform.position, Quaternion.identity, transform);
    }

    // �G�U���Q�F�̓�����
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
        Debug.Log("�U���Q��Player�Ƀ_���[�W");
        // UI�ɃG�t�F�N�g��������
    }
}
