using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class HealthGauge : MonoBehaviour//Hpゲージの管理
{
    public Image hpFillImage; // FillメーターのImage（バー部分）
    //public float maxHP = 100f;
    //private float currentHP;

    public void UpdateHPBar(float maxHP, float HP)//ダメージを受けたときにHPが減る。
    {
        float fillAmount = HP / maxHP;
        hpFillImage.DOFillAmount(fillAmount, 0.5f);
    }

    //void Start()//開始時にHPゲージをMaXにする。
    //{
    //    currentHP = maxHP;
    //    UpdateHPBar();
    //}

    //public void HPbarDown(float damage)//ダメージを受けたときにHPが減る。
    //{
    //    currentHP -= damage;
    //    currentHP = Mathf.Clamp(currentHP, 0, maxHP);
    //    UpdateHPBar();
    //}

    //void UpdateHPBar()//現在HPを最大HPで割ってfillAmountに代入。
    //{
    //    float fillAmount = currentHP / maxHP;
    //    hpFillImage.fillAmount = fillAmount;
    //}
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))//ダメージを受けるために仮に作った
    //    {
    //        HPbarDown(5f);
    //    }
    //}
}