using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HPSystemController : MonoBehaviour
{
    public static HPSystemController instance;
    private int currentHealth;
    [SerializeField] int maxHealth;
    [SerializeField] private Image[] health;

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
            CharacterControls.instance.isDead = true;
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
