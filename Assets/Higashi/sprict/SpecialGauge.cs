using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class SpecialGauge : MonoBehaviour//SPゲージの管理
{
    [SerializeField] Image SPFillImage;
    // FillメーターのImage（バー部分）
    //public float maxSP = 100f;
    //public float minSP = 0f;
    //private float currentSP;
    public void UpdateGaugeBar(float maxGauge, float currentGauge)//ダメージを受けたときにHPが減る。
    {
        //DOTween使いたい
        float fillAmount = currentGauge / maxGauge;
        SPFillImage.DOFillAmount(fillAmount, 0.5f).OnComplete(() =>
        {
            if (currentGauge >= maxGauge)
            {
                SPFillImage.DOFillAmount(0, 0.1f);
            }
        });
    }

    //void Start()//開始時にSPゲージ0にする。
    //{
    //    currentSP = minSP;
    //    UpdateSPBar();
    //}
    //public void SPbarUp(float UP)//SPバーを貯める。敵を倒した時呼び出してください。ダメージを受けたときも。
    //{
    //    currentSP += UP;
    //    currentSP = Mathf.Clamp(currentSP, 0, maxSP);
    //    UpdateSPBar();
    //}
    //public void SPreset()//SPゲージをリセットする。技を使った後に呼び出して。 
    //{
    //    currentSP = 0;
    //    UpdateSPBar();
    //}
    //void UpdateSPBar()
    //{
    //    float SPfillAmount = currentSP / maxSP;
    //    SPFillImage.fillAmount = SPfillAmount;
    //}
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.Space))//ダメージを受けるために仮に作った。
    //    {
    //        SPbarUp(1f);
    //    }
    //    if (Input.GetKeyDown(KeyCode.R))//Rボタンで必殺技を仮に打ったとする処理。
    //    {
    //        SPreset();
    //    }
    //}
}
