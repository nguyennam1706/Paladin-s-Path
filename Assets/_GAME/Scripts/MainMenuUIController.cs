using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] RankText = new TextMeshProUGUI[5];
    
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < RankText.Length; i++)
        {
            if(LBManager.instance.Exp[i] > 0)
            {
                RankText[i].text = "Exp: " + LBManager.instance.Exp[i];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGame()
    {
        LBManager.instance.isSavedLevel = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
