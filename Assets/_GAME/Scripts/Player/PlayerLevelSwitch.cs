using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelSwitch : MonoBehaviour
{
    public static PlayerLevelSwitch instance;
    public List<PlayerLevel> playerLevels = new List<PlayerLevel>();
    private int currentPlayerLevel;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Only 1 instance " + gameObject.name);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        CenterGameData.instance.SetMaxPlayLevel(playerLevels.Count);
    }

    // Update is called once per frame
    void Update()
    {
        currentPlayerLevel = CenterGameData.instance.GetPlayLevel();
        if(CenterGameData.instance.currentExp >= playerLevels[currentPlayerLevel].expToLvUp && currentPlayerLevel < CenterGameData.instance.GetMaxPlayLevel())
        {
            currentPlayerLevel++;
            CenterGameData.instance.SetPlayLevel(currentPlayerLevel);
        }
    }

    public PlayerLevel CurrentLevel()
    {
        return playerLevels[currentPlayerLevel];
    }
}
