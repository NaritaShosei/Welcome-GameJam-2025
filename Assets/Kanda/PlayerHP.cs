using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHP : MonoBehaviour
{
    [SerializeField] int _maxHP;
    int _hp;
    [SerializeField] HealthGauge _gauge;

    private void Start()
    {
        _hp = _maxHP;
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
        //後で死亡処理作る
    }
}
