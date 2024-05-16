using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    static readonly string Rank1_Exp = "Rank1Exp";
    static readonly string Rank2_Exp = "Rank2Exp";
    static readonly string Rank3_Exp = "Rank3Exp";
    static readonly string Rank4_Exp = "Rank4Exp";
    static readonly string Rank5_Exp = "Rank5Exp";
    static readonly string Rank1_Level = "Rank1Level";
    static readonly string Rank2_Level = "Rank2Level";
    static readonly string Rank3_Level = "Rank3Level";
    static readonly string Rank4_Level = "Rank4Level";
    static readonly string Rank5_Level = "Rank5Level";
    
    // Start is called before the first frame update
    void Start()
    {
        GetRank(Rank1_Exp);
        GetRank(Rank2_Exp);
        GetRank(Rank3_Exp);
        GetRank(Rank4_Exp);
        GetRank(Rank5_Exp);
        GetRank(Rank1_Level);
        GetRank(Rank2_Level);
        GetRank(Rank3_Level);
        GetRank(Rank4_Level);
        GetRank(Rank5_Level);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetRank(string rankHash)
    {
        return PlayerPrefs.GetInt(rankHash);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
