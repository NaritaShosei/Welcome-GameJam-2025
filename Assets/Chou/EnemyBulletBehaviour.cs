using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    // Player�ɓ�����܂ł̎���
    [SerializeField] float TimePeriodToHit = default;
    // ������Ƃ��̊g��{��
    [SerializeField] float ScaleToHit = default;
    GameObject player = default;
    // �t���[�����̊g��{���̑������
    float ZoomScaleCountUp = default;
    float ZoomScale = default;
    // ��������Ă���̌o�ߎ���
    float TimePast = default;
    // �e�̈ړ����x
    Vector2 BulletVelocity = default;
    // �e�̐F
    public int Color = default;

    void Start()
    {
        TimePast = 0;
        ZoomScaleCountUp = ScaleToHit / (TimePeriodToHit * (1f / Time.deltaTime)) / 2;
        ZoomScale = 1f;
        Debug.Log("�e�̐F:" + Color);
        float bulletX = Random.Range(-1.5f, 1.5f);
        float bulletY = Random.Range(-1.5f, 1.5f);
        BulletVelocity = new Vector2(bulletX, bulletY);
        gameObject.GetComponent<Rigidbody2D>().velocity = BulletVelocity;
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // �g��{�����Z�o����
        ZoomScale = 1f + (ScaleToHit * TimePast / TimePeriodToHit);
        transform.localScale = (Vector3) new Vector2(ZoomScale, ZoomScale);

        TimePast += Time.deltaTime;
        // �o�ߎ��Ԃ������鎞�Ԃ��傫���ꍇ�APlayer�Ƀ_���[�W
        if (TimePast > TimePeriodToHit)
        {
            DoDamageToPlayer();
        }
    }

    void DoDamageToPlayer()
    {
        Debug.Log("�e��Player�Ƀ_���[�W");

        Destroy(this.gameObject);
        // UI�ɃG�t�F�N�g��������
    }
}
