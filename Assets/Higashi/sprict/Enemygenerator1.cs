using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemygenerator1 : MonoBehaviour
{
    [SerializeField]private GameObject[] enemyPrefabs;    // ��������G�̃v���n�u(�����Ή�)
    [SerializeField] Transform[] spawnPoints;    // �G�̏o���ʒu�i�����Ή��j
    [SerializeField] float spawnInterval = 3f;   // �G�𐶐�����Ԋu�i�b�j

    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = spawnInterval;//timer�ɐ������Ԃ����B
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0f)
        {
            SpawnEnemy();
            timer = spawnInterval;
        }

    }
    void SpawnEnemy()
    {
        if (enemyPrefabs.Length == 0 || spawnPoints.Length == 0) return;

        // �����_���ȓG�ƃX�|�[���|�C���g��I��
        GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // �G�𐶐�
        Instantiate(selectedEnemy, spawnPoint.position, spawnPoint.rotation);
    }
}
