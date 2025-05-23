using UnityEngine;
using UnityEngine.UI;

public class ColorChanger : MonoBehaviour
{
    /// <summary>色の配列</summary>
    [SerializeField] Color[] _colors = default;
    [SerializeField] Image[] _images;
    [SerializeField] Image _background;
    public Color Color;
    int _index;
    //float _scrollSum;
    [SerializeField]
    float _scrollValue = 0.5f;

    private void Start()
    {
        Color = _colors[0];
        _images[0].transform.localScale = Vector3.one * 1.2f;
        _background.transform.position = _images[0].transform.position;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Color = _colors[0];
            _images[0].transform.localScale = Vector3.one * 1.2f;
            _images[1].transform.localScale = Vector3.one;
            _images[2].transform.localScale = Vector3.one;
            _background.transform.position = _images[0].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Color = _colors[1];
            _images[0].transform.localScale = Vector3.one;
            _images[1].transform.localScale = Vector3.one * 1.2f;
            _images[2].transform.localScale = Vector3.one;
            _background.transform.position = _images[1].transform.position;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Color = _colors[2];
            _images[0].transform.localScale = Vector3.one;
            _images[1].transform.localScale = Vector3.one;
            _images[2].transform.localScale = Vector3.one * 1.2f;
            _background.transform.position = _images[2].transform.position;
        }
        //float scroll = Input.GetAxis("Mouse ScrollWheel");

        //_scrollSum += scroll;

        //if (_scrollSum >= _scrollValue)
        //{
        //    _scrollSum = 0;
        //    _index = (_index + 1) % _colors.Length;
        //    Color = _colors[_index];
        //}
        //else if (_scrollSum <= -_scrollValue)
        //{
        //    _scrollSum = 0;
        //    _index = (_index - 1 + _colors.Length) % _colors.Length;
        //    Color = _colors[_index];
        //}

        //if (Input.GetButtonDown("Fire2"))
        //{
        //    _index = (_index + 1) % _colors.Length;
        //    Color = _colors[_index];
        //}
    }
}
