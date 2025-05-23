using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

/// <summary>
/// 説明パネルを管理するクラス
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
    /// パネルを非表示にするメソッド
    /// </summary>
    public void Hide()
    {
        _canvasGroup.DOFade(0f, _duration); // アルファ値を0にする
        _canvasGroup.interactable = false;
        _canvasGroup.blocksRaycasts = false;
    }

    /// <summary>
    /// パネルを表示するメソッド
    /// </summary>
    public void Show()
    {
        _canvasGroup.DOFade(1f, _duration); // アルファ値を1にする
        // transform型.DOScale(変化後の値(Vector3), 何秒かけるか);
        _canvasGroup.interactable = true;
        _canvasGroup.blocksRaycasts = true;
    }
}
