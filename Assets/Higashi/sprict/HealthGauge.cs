using UnityEngine;
using UnityEngine.UI;

public class HealthGauge : MonoBehaviour//Hp�Q�[�W�̊Ǘ�
{
    public Image hpFillImage; // Fill���[�^�[��Image�i�o�[�����j
    public float maxHP = 100f;
    private float currentHP;

    void Start()//�J�n����HP�Q�[�W��MaX�ɂ���B
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void HPbarDown(float damage)//�_���[�W���󂯂��Ƃ���HP������B
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPBar();
    }

    void UpdateHPBar()//����HP���ő�HP�Ŋ�����fillAmount�ɑ���B
    {
        float fillAmount = currentHP / maxHP;
        hpFillImage.fillAmount = fillAmount;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//�_���[�W���󂯂邽�߂ɉ��ɍ����
        {
            HPbarDown(5f);
        }
    }
}