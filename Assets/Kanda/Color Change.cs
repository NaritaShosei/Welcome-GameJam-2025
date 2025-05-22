using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    /// <summary>色の配列</summary>
    [SerializeField] Color[] _colors = default;
    public Color Color;
    int _index;

    private void Start()
    {
        Color = _colors[0];
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("色を切り替える処理");
            Color = _colors[_index];
            _index++;
            _index %= _colors.Length;
        }
    }
}
