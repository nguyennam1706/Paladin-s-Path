using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySwitch : MonoBehaviour
{
    public UnityEngine.U2D.Animation.SpriteLibrary Enemy;
    public UnityEngine.U2D.Animation.SpriteLibraryAsset[] Enemies;
    private EnemyLevelSwitch enemyLevelSwitch;
    private int _index;

    private void Start()
    {
        enemyLevelSwitch = this.GetComponent<EnemyLevelSwitch>();
        _index = enemyLevelSwitch.CurrentLevel();
        Enemy.spriteLibraryAsset = Enemies[_index];
    }
}
