using UnityEngine;

public class Enemygenerator2 : MonoBehaviour//敵を画面四隅の外に生成する。
{
    [SerializeField]GameObject[] enemyPrefabs;
    [SerializeField] float spawnInterval = 3f; // 生成間隔（秒）

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
        // カメラ右外にランダムなY位置で生成 <- ランダムじゃないよ＾＾
        Vector3 viewportPos = new Vector3(1f, 1.2f, 0f);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(viewportPos);
        worldPos.z = 0;
        GameObject selectedEnemy = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        Instantiate(selectedEnemy, worldPos, Quaternion.identity);
    }
}
