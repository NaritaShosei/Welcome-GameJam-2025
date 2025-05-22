using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    // Player�ɓ�����܂ł̎��ԁi�b�j
    [SerializeField] float TimePeriodToHit = default;
    // ������Ƃ��̊g��{���y�Q�l�l:3�z
    [SerializeField] float ScaleToHit = default;
    // �t���[�����̐ݒ�p�g��{��
    float ZoomScale = default;
    // ��������Ă���̌o�ߎ���
    float TimePast = default;
    // �e�̈ړ����x
    Vector2 BulletVelocity = default;
    // �e�̐F
    public int Color = default;

    // ��ʒ���

    void Start()
    {
        TimePast = 0;
        ZoomScale = 1f;
        Debug.Log("�e�����B�F:" + Color);

        // �����_���ő��x��t�^����
        float bulletX = Random.Range(-1f, 1f);
        float bulletY = Random.Range(-1f, 1f);
        BulletVelocity = new Vector2(bulletX, bulletY);
        gameObject.GetComponent<Rigidbody2D>().velocity = BulletVelocity;
    }

    // Update is called once per frame
    void Update()
    {
        TimePast += Time.deltaTime;

        // �g��{�����Z�o����
        ZoomScale = 1f + (ScaleToHit * TimePast / TimePeriodToHit);
        transform.localScale = new Vector2(ZoomScale, ZoomScale);

        // �o�ߎ��Ԃ������鎞�Ԃ��傫���ꍇ�APlayer�Ƀ_���[�W
        if (TimePast > TimePeriodToHit)
        {
            DoDamageToPlayer();
        }
    }

    // �v���C���[�_���[�W����
    void DoDamageToPlayer()
    {
        Debug.Log("�e��Player�Ƀ_���[�W");

        Destroy(this.gameObject);
        // UI�ɃG�t�F�N�g��������
    }
}
