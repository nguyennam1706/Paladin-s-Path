using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTilemap : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0f;
    public float limitDis;
    public float respawnDis;
    [SerializeField] private List<GameObject> tileMaps;

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
        SpawnTileMap();
    }

    private void GetDistance()
    {
        this.currentDis = this.player.position.x - transform.position.x;
    }

    private void SpawnTileMap()
    {
        GameObject tileMap = tileMaps[Random.Range(0, this.tileMaps.Count)];
        tileMap.transform.position = transform.position;
        foreach(GameObject tile in tileMaps)
        {
            if (tile.name == tileMap.name) 
            {
                tile.SetActive(true);
            }
            else
            {
                tile.SetActive(false);
            }
        }
    }
}
