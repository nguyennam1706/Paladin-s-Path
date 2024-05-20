using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LBManager : MonoBehaviour
{
    static readonly string[] RankExp = new string[5]
    {
        "Rank1Exp", "Rank2Exp", "Rank3Exp", "Rank4Exp", "Rank5Exp"
    };
    
    public static LBManager instance;
    public List<int> Exp;
    public bool isSavedLevel = false;
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
        }
        for (int i = 0; i < RankExp.Length; i++)
        {
            if (GetRank(RankExp[i]) > 0)
            {
                Exp.Add(GetRank(RankExp[i]));
            }
        }
        SortList(Exp);
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
        
    }

    private void Update()
    {
        for (int i = 0; i < RankExp.Length; i++)
        {
            SetRank(Exp[i], RankExp[i]);
        }
    }

    public int GetRank(string rankHash)
    {
        return PlayerPrefs.GetInt(rankHash);
    }

    public void SetRank(int val, string rankHash)
    {
        PlayerPrefs.SetInt(rankHash, val);
        PlayerPrefs.Save();
    }

    public void InsertExp(int val)
    {
        int index = FindIndexToInsert(Exp, val);
        Exp.Insert(index, val);
        SortList(Exp);
    }

    private int FindIndexToInsert(List<int> list, int number)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (number >= list[i])
            {
                return i;
            }
        }
        return list.Count;
    }

    private void SortList(List<int> list)
    {
        list.Sort(CompareDescending);
    }

    private int CompareDescending(int a, int b)
    {
        if (a > b)
        {
            return -1;
        }
        else if (a < b)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }
}
