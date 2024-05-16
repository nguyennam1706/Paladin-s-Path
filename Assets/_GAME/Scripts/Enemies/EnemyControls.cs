using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControls : MonoBehaviour
{
    private Enemy enemy;
    private EnemyData enemyData;
    // Start is called before the first frame update
    void Start()
    {
        enemy = this.GetComponent<Enemy>();
        enemyData = this.GetComponent<EnemyLevelSwitch>().CurrentEnemyData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool IsAboveEnemy()
    {
        return transform.position.y > -1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.CompareTag("PlayerAttack"))
            {
                CenterGameData.instance.AddExp(1);
                Destroy(this.gameObject);
            }
            if(collision.gameObject.CompareTag("DeathZone"))
            {
                Destroy(this.gameObject);
            }
        }
    }
}
