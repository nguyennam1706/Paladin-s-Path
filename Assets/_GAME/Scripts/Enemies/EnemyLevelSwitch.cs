using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLevelSwitch : MonoBehaviour
{
    public List<EnemyData> enemyData = new List<EnemyData>();
    private int currentEnemyLevel;
    // Start is called before the first frame update
    void Start()
    {
        currentEnemyLevel = Random.Range(0, enemyData.Count);
    }

    public EnemyData CurrentEnemyData()
    {
        return enemyData[currentEnemyLevel];
    }

    public int CurrentLevel()
    {
        return currentEnemyLevel;
    }
}
