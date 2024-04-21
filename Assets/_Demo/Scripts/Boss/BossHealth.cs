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
    [SerializeField] private Image healthBarBackground;
    private BossAnimation bossAnimation;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = bossData.bossHealth;
        bossAnimation = transform.GetChild(0).GetComponent<BossAnimation>();
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
        if(isDead)
        {
            StartCoroutine(Death());
        }
    }

    public void RecoverHealth(float health)
    {
        currentHealth += health;
    }

    public void TakenDamage(float health)
    {
        currentHealth -= health;
    }

    IEnumerator Death()
    {
        bossAnimation.AnimDeath();
        healthBarBackground.gameObject.SetActive(false);
        healthBar.gameObject.SetActive(false);
        this.GetComponent<BossController>().enabled = false;
        this.GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}
