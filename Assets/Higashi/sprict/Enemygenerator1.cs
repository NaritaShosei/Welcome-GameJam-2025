using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygenerator1 : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;    // 生成する敵のプレハブ(複数対応)
    [SerializeField] Transform[] spawnPoints;    // 敵の出現位置（複数対応）
    [SerializeField] float spawnInterval = 3f;   // 敵を生成する間隔（秒）
    [SerializeField] float _intervalDelta = 0.2f;
    [SerializeField] float _minInterval = 1.5f;

    EnemyManager _enemyManager;

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        _enemyManager = GetComponent<EnemyManager>();
        timer = spawnInterval;//timerに生成時間を代入。
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enemyManager.IsEnemyMax()) return;
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            //Intervalを徐々に減らし、加減で止める
            spawnInterval = Mathf.Max(spawnInterval - _intervalDelta, _minInterval);
            timer = spawnInterval;
        }

    }
    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0 || spawnPoints.Length == 0) return;

        // ランダムな敵とスポーンポイントを選ぶ
        GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // 敵を生成
        Instantiate(selectedEnemy, spawnPoint.position, spawnPoint.rotation);
    }
}
