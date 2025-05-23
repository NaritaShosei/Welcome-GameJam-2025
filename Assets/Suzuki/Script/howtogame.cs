using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// �����p�l�����Ǘ�����N���X
/// </summary>
public class howtogame : MonoBehaviour
{
    [SerializeField] private float _duration = 1f;
    [SerializeField] private CanvasGroup _canvasGroup;

    private void Start()
    {
        Hide();
    }

    /// <summary>
    /// �p�l�����\���ɂ��郁�\�b�h
    /// </summary>
    public void Hide()
    {
        _canvasGroup.DOFade(0f, _duration); // �A���t�@�l��0�ɂ���
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// �p�l����\�����郁�\�b�h
    /// </summary>
    public void Show()
    {
        _canvasGroup.DOFade(1f, _duration); // �A���t�@�l��1�ɂ���
        // transform�^.DOScale(�ω���̒l(Vector3), ���b�����邩);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
}
