using UnityEngine;
using UnityEngine.UI;

public class HPBar : MonoBehaviour
{
    public Image hpFillImage; // FillメーターのImage（バー部分）
    public float maxHP = 100f;
    private float currentHP;

    void Start()
    {
        currentHP = maxHP;
        UpdateHPBar();
    }

    public void TakeDamage(float damage)//ダメージを受けたときにHPが減る。
    {
        currentHP -= damage;
        currentHP = Mathf.Clamp(currentHP, 0, maxHP);
        UpdateHPBar();
    }

    void UpdateHPBar()//現在HPを最大HPで割ってfillAmountに代入。
    {
        float fillAmount = currentHP / maxHP;
        hpFillImage.fillAmount = fillAmount;
    }
    void Update()//ダメージを受けるために仮に作った
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(5f);
        }
    }
}