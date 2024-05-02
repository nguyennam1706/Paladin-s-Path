using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameUIController : MonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI expTxt;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        expTxt.text = "" + CenterGameData.instance.currentExp + " / " + PlayerLevelSwitch.instance.CurrentLevel().expToLvUp;
    }
}
