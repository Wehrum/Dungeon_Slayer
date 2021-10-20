using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject bossPrefab;
    public Transform bossSpawn;

    void Start()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            {
                int ranEnemy = Random.Range(0, enemyPrefabs.Length);
                int spawnPoint = Random.Range(0, spawnPoints.Length);
                Instantiate(enemyPrefabs[ranEnemy], spawnPoints[spawnPoint].position, transform.rotation);
            }
        }
        Instantiate(bossPrefab, bossSpawn);
    }
}



// Start is called before the first frame update
//public void RandomSpawn()
//{

//for (int i = 0; i < enemyPrefabs.Length; i++)
//{
//    int ranEnemy = Random.Range(0, enemyPrefabs.Length);
//    int spawnPoint = Random.Range(0, spawnPoints.Length);
//    Instantiate(enemyPrefabs[ranEnemy], spawnPoints[spawnPoint].position, transform.rotation);
//}
//if (true == (sceneNames == "Dungeon1"))

//} 


