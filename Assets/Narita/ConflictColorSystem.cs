using Unity.VisualScripting;
using UnityEngine;

public class ConflictColorSystem : MonoBehaviour
{
    [SerializeField, Tooltip("Enemyの色の配列")]
    Color[] _colors = new Color[] { Color.red, Color.blue, Color.green, Color.cyan, Color.magenta, new Color(1, 1, 0, 1) };
    Color _color;

    bool _isChanged;

    SpriteRenderer _sr;
    private void Start()
    {
        //すでに色が変更されていたら処理を抜け出す
        if (_isChanged) return;

        //ランダムな色に変更
        var rIndex = Random.Range(0, _colors.Length);
        _color = _colors[rIndex];
        _sr = GetComponent<SpriteRenderer>();
        _sr.color = _color;
    }


    public bool Hit(Color bulletColor)
    {
        //色の減算
        _color = _color.AddColor(-1 * bulletColor);

        //引いた色が黒になったら死亡
        if (_color == Color.black)
        {
            _sr.enabled = false;
            Destroy(this.gameObject);
        }
        _sr.color = _color;

        return _color == Color.black;
    }

    public void ColorChange(Color color)
    {
        _sr = GetComponent<SpriteRenderer>();
        _color = color;
        _sr.color = _color;
        _isChanged = true;
    }

}
public static class ColorUtility
{
    //Colorの拡張メソッド
    public static Color AddColor(this Color a, Color b)
    {
        return new Color(
             Mathf.Max(a.r + b.r, 0),
             Mathf.Max(a.g + b.g, 0),
             Mathf.Max(a.b + b.b, 0),
             1);
    }
}