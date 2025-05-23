using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    /// <summary>色の配列</summary>
    [SerializeField] Color[] _colors = default;
    public Color Color;
    int _index;
    //float _scrollSum;
    [SerializeField]
    float _scrollValue = 0.5f;
    private void Start()
    {
        Color = _colors[0];
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Color = _colors[0];
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            Color = _colors[1];
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Color = _colors[2];
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
