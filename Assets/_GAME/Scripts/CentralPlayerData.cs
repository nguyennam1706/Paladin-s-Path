using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CentralPlayerData : MonoBehaviour
{
    public static CentralPlayerData instance;

    [SerializeField] int coin = 0;
    public int Coin => coin;
    
    [SerializeField] int exp = 0;
    public int Exp => exp;

    static readonly string CoinHash = "CoinHash";
    static readonly string ExpHash = "ExpHash";
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
        GetCoin();
        GetExp();
    }

    public int GetCoin()
    {
        coin = PlayerPrefs.GetInt(CoinHash);

        return coin;
    }

    public void SetCoin(int val)
    {
        val = Mathf.Clamp(val, 0, val);

        coin = val;

        PlayerPrefs.SetInt(CoinHash, val);
    }

    public void AddCoin(int val)
    {
        int caculatedCoin = GetCoin() + val;

        caculatedCoin = Mathf.Clamp(caculatedCoin, 0, caculatedCoin);

        SetCoin(caculatedCoin);
    }

    public void UseCoin(int val)
    {
        int caculatedCoin = GetCoin() - val;

        SetCoin(caculatedCoin);
    }
    
    public int GetExp()
    {
        exp = PlayerPrefs.GetInt(ExpHash);

        return exp;
    }

    public void SetExp(int val)
    {
        val = Mathf.Clamp(val, 0, val);

        exp = val;

        PlayerPrefs.SetInt(ExpHash, val);
    }

    public void AddExp(int val)
    {
        int caculatedExp = GetExp() + val;

        caculatedExp = Mathf.Clamp(caculatedExp, 0, caculatedExp);

        SetExp(caculatedExp);
    }

    public void ResetExp()
    {
        SetExp(0);
    }
}
