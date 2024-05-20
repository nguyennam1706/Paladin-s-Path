using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinOpenController : MonoBehaviour
{
    [SerializeField] private List<Transform> SkinList = new();
    private void OnEnable()
    {
        int skinOpened = CenterGameData.instance.GetUnlockedLevel();
        for(int i = 0; i <= skinOpened; i++)
        {
            SkinList[i].Find("Lock").gameObject.SetActive(false);
        }
    }
}
