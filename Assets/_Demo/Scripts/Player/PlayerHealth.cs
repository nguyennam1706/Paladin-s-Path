using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Instance;
    public PlayerData playerData;
    private float currentHealth;
    private float currentMana;
    public bool isDead;
    public bool isManaZero;
    [SerializeField] private Image healthBar;
    [SerializeField] private Image manaBar;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerData.playerHealth;
        currentMana = playerData.playerMana;
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

        if(currentHealth >= playerData.playerHealth)
        {
            currentHealth = playerData.playerHealth;
        }
        if (currentMana <= 0)
        {
            currentMana = 0;
            isManaZero = true;
        }
        else
        {
            isManaZero = false;
        }

        if(currentMana >= playerData.playerMana)
        {
            currentMana = playerData.playerMana;
        }

        healthBar.fillAmount = (float)currentHealth / playerData.playerHealth;
        manaBar.fillAmount = (float)currentMana / playerData.playerMana;

    }

    public void RecoverHealth(float health)
    {
        currentHealth += health;
    }

    public void TakenDamage(float health)
    {
        currentHealth -= health;
    }

    public void SkillMana(float mana)
    {
        currentMana -= mana;
    }
    public void RecoverMana(float mana)
    {
        currentMana += mana;
    }
}
