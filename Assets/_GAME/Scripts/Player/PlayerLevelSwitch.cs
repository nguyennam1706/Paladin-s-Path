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
    // Start is called before the first frame update
    void Start()
    {
        currentPlayerLevel = CenterGameData.instance.GetPlayLevel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public PlayerLevel CurrentLevel()
    {
        return playerLevels[currentPlayerLevel];
    }
}
