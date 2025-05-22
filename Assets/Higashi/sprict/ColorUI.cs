using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorUI : MonoBehaviour
{
    [SerializeField] ColorChanger _changer;
    [SerializeField] Image _image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _image.colorÅ@= _changer.Color;
    }
}
