using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int _maxHP;
    int _hp;
    [SerializeField] HealthGauge _gauge;
    [SerializeField] AnimationCurve _curve;
    [SerializeField] float _duration;
    float _timer;
    bool _isPlaying;

    public bool IsDead => _hp <= 0;
    private void Start()
    {
        _hp = _maxHP;
    }
    private void Update()
    {
        if (_isPlaying)
        {
            _timer += Time.unscaledDeltaTime;
            float t = Mathf.Clamp01(_timer / _duration);
            Time.timeScale = _curve.Evaluate(t);

            if (t >= 1)
            {
                _isPlaying = false;
            }
        }
    }
    public void AddDamage()
    {
        _hp -= 1;
        _gauge.UpdateHPBar(_maxHP, _hp);
        if (_hp <= 0)
        {
            Dead();
        }
    }
    private void Dead()
    {
        _isPlaying = true;
    }
}
