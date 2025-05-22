using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpFillImage; // Fill���[�^�[��Image�i�o�[�����j
    public float maxHP = 100f;
    private float currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(float damage)//�_���[�W���󂯂��Ƃ���HP������B
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
    void Update()//�_���[�W���󂯂邽�߂ɉ��ɍ����
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5f);
        }
    }
}