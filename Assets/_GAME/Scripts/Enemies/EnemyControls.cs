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
}
