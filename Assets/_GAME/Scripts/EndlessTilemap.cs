using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTilemap : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0f;
    public float limitDis;
    public float respawnDis;
    [SerializeField] protected List<GameObject> enemySpawnPos = new List<GameObject>();
    [SerializeField] protected GameObject enemy;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < enemySpawnPos.Count; i++)
        {
            Instantiate(enemy, enemySpawnPos[i].transform.position, enemySpawnPos[i].transform.rotation);
        }
    }

    protected void FixedUpdate()
    {
        this.GetDistance();
        this.Spawning();
    }

    private void Spawning()
    {
        if (this.currentDis < this.limitDis) return;
        Vector3 pos = transform.position;
        pos.x += this.respawnDis;
        transform.position = pos;
        SpawnEnemy();
    }

    private void GetDistance()
    {
        this.currentDis = this.player.position.x - transform.position.x;
    }
}
