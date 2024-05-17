using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterGameData : MonoBehaviour
{
    public static CenterGameData instance;

    public int unlockedLevel = 0;

    public int playLevel = 0;

    public int currentExp;

    static string unlockedLevelHash = "UnlockedLevel";
    static string playLevelHash = "PlayLevel";
    static string maxPlayLevelHash = "MaxPlayLevel";

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

    public void AddExp(int exp)
    {
        currentExp += exp;
    }

    public void ResetExp()
    {
        currentExp = 0;
    }

    public int GetPlayLevel()
    {
        playLevel = PlayerPrefs.GetInt(playLevelHash);
        return playLevel;
    }

    public int GetMaxPlayLevel()
    {
        return PlayerPrefs.GetInt(maxPlayLevelHash);
    }

    public void SetMaxPlayLevel(int levelIndex)
    {
        int currentMaxPlayLevel = GetMaxPlayLevel();
        PlayerPrefs.SetInt(maxPlayLevelHash, Mathf.Max(levelIndex, currentMaxPlayLevel));
        PlayerPrefs.Save();
    }

    public void SetPlayLevel(int levelIndex)
    {
        if (levelIndex < GetMaxPlayLevel())
        {
            PlayerPrefs.SetInt(playLevelHash, levelIndex);
        }
        else
        {
            PlayerPrefs.SetInt(playLevelHash, GetMaxPlayLevel());
        }
    }


    public int GetUnlockedLevel()
    {
        unlockedLevel = PlayerPrefs.GetInt(unlockedLevelHash);

        return unlockedLevel;
    }

    void SetUnlockedLevel(int levelIndex)
    {
        if (levelIndex <= GetUnlockedLevel())
        {
            return;
        }

        PlayerPrefs.SetInt(unlockedLevelHash, levelIndex);

        GetUnlockedLevel();
    }

    public void UnlockNextLevel(int currentLevel, int maxLvlIndex)
    {
        int unlockLevel = Mathf.Clamp(currentLevel, 0, maxLvlIndex);

        SetUnlockedLevel(unlockLevel);

        SetPlayLevel(unlockLevel);
    }

    public void ResetLevel()
    {
        SetPlayLevel(0);
    }

    public int GetRank(string rankHash)
    {
        return PlayerPrefs.GetInt(rankHash);
    }

    public void SetRank(string rankHash, int val)
    {
        PlayerPrefs.SetInt(rankHash, val);
    }
}
