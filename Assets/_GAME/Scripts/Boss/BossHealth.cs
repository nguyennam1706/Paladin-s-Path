using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    public BossData bossData;
    private float currentHealth;
    public bool isDead;
    [SerializeField] private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = bossData.bossHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true;
        }
        else
        {
            isDead = false;
        }

        if (currentHealth >= bossData.bossHealth)
        {
            currentHealth = bossData.bossHealth;
        }

        healthBar.fillAmount = (float)currentHealth / bossData.bossHealth;

    }

    public void RecoverHealth(float health)
    {
        currentHealth += health;
    }

    public void TakenDamage(float health)
    {
        currentHealth -= health;
    }
}
