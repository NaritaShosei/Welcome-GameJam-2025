using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Rendering;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // �U���P�̒ePrefab
    [SerializeField] GameObject EnemyBullet = default;
    // �U���Q�̏����́u�ցvPrefab
    [SerializeField] GameObject EnemyAttack2Ring = default;
    // �U���Ԋu(�b)
    [SerializeField]  float AttackInterval = 5f;
    // �U���Q���o�̊g�呬�x�y�Q�l�l:0.04�z
    [SerializeField] float Attack2ScaleSpeed = default;
    // �U���Q���o�̍ŏI�g��{���y�Q�l�l:2�z
    [SerializeField] float Attack2Scale = default;

    // �U���N�[���_�E��
    float AttackCooldown = default;
    // �G�̐F
    int Color = default;
    // ��ԃt���O�F�U���Q���o��
    bool InAttack2 = default;
    // ��ԃt���O�F�U���Q���o�g�咆
    bool Attack2Arriving = default;
    // ��ԃt���O�F�U���Q���o�߂蒆
    bool Attack2Hit = default;
    // �t���[�����̊g��{��
    float ZoomScale = default;
    // �����g��{��
    float InitZoomScale = default;

    // debug�p
    [SerializeField] bool DebugSwitch = default;

    void Start()
    {
        Color = Random.Range(1, 4);
        Debug.Log("�G�����B�F�F" + Color);
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
            // DEBUG�p�F�X�y�[�X�L�[�ōU���������_���ōs��
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
            // DEBUG�p�F�����L�[�u1�v�ōU���P���s��
            else if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                DoAttack1();
            }
            // DEBUG�p�F�����L�[�u2�v�ōU���Q���s��
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                PrepareAttack2();
            }
        } else {
            AttackCooldown -= Time.deltaTime;

            if (AttackCooldown <= 0)
            {
                // �U���\�ɂȂ�ƁA�U���P���Q�������_���ł���
                int attackNum = Random.Range(1, 3);
                if (attackNum == 1)
                {
                    DoAttack1();
                }
                else
                {
                    PrepareAttack2();
                }
                // �U���N�[���_�E�������Z�b�g
                AttackCooldown = AttackInterval;
            }
        }
        // �U���Q���o���̏���
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

    // �G�U���Q�F�U���J�n
    public void StartAttack2()
    {
        InAttack2 = true;
        Attack2Arriving = true;
    }

    // �G�U���Q�F�U�����o
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
    // �v���C���[�_���[�W����
    void DoDamageToPlayer()
    {
        Debug.Log("�U���Q��Player�Ƀ_���[�W");
        // UI�ɃG�t�F�N�g��������
    }
}
