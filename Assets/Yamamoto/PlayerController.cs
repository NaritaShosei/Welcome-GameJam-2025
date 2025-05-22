using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    float specialGauge = 0f;            // �K�E�Z�Q�[�W
    [SerializeField] float gaugeMax = 100f;        // �Q�[�W�ő�l
    [SerializeField] float gaugeGain = 5f;        // 1��̍U���ő������
    //const float gaugeGainDestroy = 10f;     //�G��|�����Ƃ��ɓ����


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;

        //�U�������N���b�N�Ŕ���

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        //�K�E�Z���}�E�X�̒����{�^���Ŕ���

        if (Input.GetMouseButtonDown(2) && specialGauge >= gaugeMax)
        {
            UseSpecialMove();

        }
            

        // �K�E�Z�Q�[�W�̏�Ԃ�\���i�f�o�b�O�p�j
        Debug.Log($"�K�E�Z�Q�[�W: {specialGauge}/{gaugeMax}");


        //�G��|���ƕK�E�Z�����܂�
         //if () 
        {


        }

        void Attack()
        {
            var ray = Physics2D.Raycast(transform.position, Camera.main.transform.forward, 10);
            if (ray.collider != null && ray.collider.name == "Enemy")
            {


                Debug.Log("�C�e�b");


                // �Q�[�W�𑝉��i�ő�l�𒴂��Ȃ��悤�Ɂj
                specialGauge += gaugeGain;
                specialGauge = Mathf.Min(specialGauge, gaugeMax);
            }

            


        }



        void UseSpecialMove()
        {
            Debug.Log("�K�E�Z �����I�I");

            // �G��S�ł����鏈���i��F�^�O�� Enemy �̑S�I�u�W�F�N�g�� Destroy�j
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            
            // �Q�[�W�����Z�b�g
            specialGauge = 0f;
        }
    }
}
