using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPSystemController : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] int maxHealth;
    [SerializeField] private Image[] health;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if (currentHealth <= 0)
        {
            currentHealth = 0;
        }
        for (int i = 0; i < maxHealth; i++)
        {
            if (i < currentHealth)
            {
                health[i].gameObject.SetActive(true);
            }
            else
            {
                health[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddHealth(int heathNum)
    {
        currentHealth += heathNum;
    }
    public void ReduceHealth(int heathNum)
    {
        currentHealth -= heathNum;
    }
}
