using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack2RingBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    // Player�Ƀ_���[�W�܂ł̎��ԁi�b�j
    [SerializeField] float TimePeriodToDamage = default;
    // �����g��{���y�Q�l�l:5�z
    [SerializeField] float InitScale = default;
    // �_���[�W���̊g��{���y�Q�l�l:0�z
    [SerializeField] float HitScale = default;
    // �t���[�����̊g��{���̑������
    float ZoomScale = default;
    // ��������Ă���̌o�ߎ���
    float TimePast = default;
    void Start()
    {
        Debug.Log("�U���Q����Ring����.");
        ZoomScale = InitScale;
        TimePast = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �����̊g��{������0�܂ŏk������
        transform.localScale = new Vector2(ZoomScale, ZoomScale);
        TimePast += Time.deltaTime;
        ZoomScale = InitScale * (1 - (TimePast / TimePeriodToDamage));

        // �}�C�i�X�l�ɂȂ邱�Ƃ�h�~
        if(ZoomScale < 0f)
        {
            ZoomScale = 0f;
        }

        // �_���[�W���ԂɒB����ƁA�U���Q���o���J�n���A���g������
        if(TimePast > TimePeriodToDamage)
        {
            Debug.Log("Ring���ŁA�U���Q���{");
            GetComponentInParent<EnemyAttack>().StartAttack2();
            Destroy(gameObject);
        }
    }
}
