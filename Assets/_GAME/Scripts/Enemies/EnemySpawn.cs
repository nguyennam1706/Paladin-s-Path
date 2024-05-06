using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] protected List<GameObject> enemySpawnPos = new List<GameObject>();
    [SerializeField] protected GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < enemySpawnPos.Count; i++)
        {
            Instantiate(enemy, enemySpawnPos[i].transform.position, enemySpawnPos[i].transform.rotation);
        }
    }
}
