using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    /// <summary>�F�̔z��</summary>
    [SerializeField] Color[] _colors = default;
    Color _color;
    int _index;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            //Debug.Log("�F��؂�ւ��鏈��");
            _color = _colors[_index];
            _index++;
            _index %= _colors.Length;
        }
    }

    
}
