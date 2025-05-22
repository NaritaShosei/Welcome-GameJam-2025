using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConflictColorSystem : MonoBehaviour
{
    [SerializeField]
    List<Color> _requiredColors = new List<Color>();
    List<Color> _viewColors;

    HashSet<Color> _hitColors = new HashSet<Color>();

    SpriteRenderer _sr;

    public bool _isCheck;
    private void Start()
    {
        _sr = GetComponent<SpriteRenderer>();

        _viewColors = new(_requiredColors);

        _viewColors.Reverse();
    }

    private void Update()
    {
        if (!_isCheck) return;
        // デバッグ操作（左クリック＝赤弾、右クリック＝青弾）
        if (Input.GetMouseButtonDown(0))
        {
            Hit(Color.red);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Hit(Color.blue);
        }
    }

    public bool Hit(Color bulletColor)
    {
        if (_requiredColors.Contains(bulletColor))
        {
            if (!_hitColors.Contains(bulletColor))
            {
                Debug.Log(bulletColor);
                _hitColors.Add(bulletColor);


                if (_hitColors.Count >= _requiredColors.Count)
                {
                    Debug.Log("撃破");
                    Destroy(gameObject);
                    return true;
                }

                int index = _requiredColors.IndexOf(bulletColor);
                _sr.color = _viewColors[index];
            }
        }
        else
        {
            Debug.Log("なんやその色");
        }
        return false;
    }
}
