using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUIController : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI expTxt;
    [SerializeField] protected TextMeshProUGUI levelTxt;
    [SerializeField] protected TextMeshProUGUI speedTxt;
    [SerializeField] protected TextMeshProUGUI jumpForceTxt;
    [SerializeField] private Image characterImage;
    [SerializeField] private Sprite[] listCharacter;
    // Start is called before the first frame update
    void Start()
    {
        characterImage.sprite = listCharacter[0];
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
        SceneManager.LoadScene(0);
    }
}
