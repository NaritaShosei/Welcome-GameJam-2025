using UnityEngine;

public class Enemygenerator2 : MonoBehaviour//�G����ʎl���̊O�ɐ�������B
{
    [SerializeField]GameObject[] enemyPrefabs;
    [SerializeField] float spawnInterval = 3f; // �����Ԋu�i�b�j

    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnEnemy();
            timer = 0f;
        }
    }

    void SpawnEnemy()
    {
        // �J�����E�O�Ƀ����_����Y�ʒu�Ő���
        Vector3 viewportPos = new Vector3(1f, 1.2f, 0f);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
        worldPos.z = 0;
        GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(selectedEnemy, worldPos, Quaternion.identity);
    }
}
