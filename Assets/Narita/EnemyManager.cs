using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    List<EnemyAttack> _enemies = new();
    [SerializeField] int _maxCount = 7;
    // Start is called before the first frame update
    void Start()
    {
        _enemies = new(FindObjectsByType<EnemyAttack>(FindObjectsSortMode.None));
    }

    public void AddList(EnemyAttack enemy)
    {
        if (_enemies.Contains(enemy)) return;
        _enemies.Add(enemy);
    }

    public void RemoveList(EnemyAttack enemy)
    {
        if (!_enemies.Contains(enemy)) return;
        _enemies.Remove(enemy);
    }

    public bool IsEnemyMax()
    {
        return _enemies.Count >= _maxCount;
    }
}
