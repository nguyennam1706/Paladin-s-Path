using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessTilemap : MonoBehaviour
{
    public Transform player;
    public float currentDis = 0f;
    public float limitDis;
    public float respawnDis;

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
    }

    private void GetDistance()
    {
        this.currentDis = this.player.position.x - transform.position.x;
    }
}
