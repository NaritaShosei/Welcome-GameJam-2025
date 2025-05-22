using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.WSA;

public class SpecialGauge : MonoBehaviour//SP�Q�[�W�̊Ǘ�
{
    public Image SPFillImage; // Fill���[�^�[��Image�i�o�[�����j
    public float maxSP = 100f;
    public float minSP = 0f;
    private float currentSP;

    void Start()//�J�n����SP�Q�[�W0�ɂ���B
    {
        currentSP = minSP;
        UpdateSPBar();
    }
    public void SPbarUp(float UP)//SP�o�[�𒙂߂�B�G��|�������Ăяo���Ă��������B�_���[�W���󂯂��Ƃ����B
    {
        currentSP += UP;
        currentSP = Mathf.Clamp(currentSP, 0, maxSP);
        UpdateSPBar();
    }
    public void SPreset()//SP�Q�[�W�����Z�b�g����B�Z���g������ɌĂяo���āB 
    {
        currentSP = 0;
        UpdateSPBar();
    }
    void UpdateSPBar()
    {
        float SPfillAmount = currentSP / maxSP;
        SPFillImage.fillAmount = SPfillAmount;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))//�_���[�W���󂯂邽�߂ɉ��ɍ�����B
        {
            SPbarUp(1f);
        }
        if (Input.GetKeyDown(KeyCode.R))//R�{�^���ŕK�E�Z�����ɑł����Ƃ��鏈���B
        {
            SPreset();
        }
    }
}
