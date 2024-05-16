using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    public static GameUIController instance;
    [SerializeField] private TextMeshProUGUI expTxt;
    [SerializeField] private TextMeshProUGUI levelTxt;
    [SerializeField] private TextMeshProUGUI speedTxt;
    [SerializeField] private TextMeshProUGUI jumpForceTxt;
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite[] listCharacter;
    [SerializeField] private GameObject popupDied;

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
    }

    // Start is called before the first frame update
    void Start()
    {
        characterImage.sprite = listCharacter[0];
        popupDied.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        speedTxt.text = "Speed: " + PlayerLevelSwitch.instance.CurrentLevel().runSpeed;
        jumpForceTxt.text = "Jump Force: " + PlayerLevelSwitch.instance.CurrentLevel().jumpSpeed;
        levelTxt.text = "" + (CenterGameData.instance.GetPlayLevel() + 1);
        expTxt.text = "" + CenterGameData.instance.currentExp + " / " + PlayerLevelSwitch.instance.CurrentLevel().expToLvUp;
        characterImage.sprite = listCharacter[CenterGameData.instance.GetPlayLevel()];
    }

    public void Home()
    {
        CenterGameData.instance.ResetLevel();
        CenterGameData.instance.ResetExp();
        SceneManager.LoadScene(0);
    }

    public void SetActivePopup()
    {
        popupDied.SetActive(true);
    }

    public void RePlay()
    {
        CenterGameData.instance.ResetLevel();
        CenterGameData.instance.ResetExp();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
