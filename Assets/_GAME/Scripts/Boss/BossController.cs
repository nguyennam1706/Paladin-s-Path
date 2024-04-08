using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossController : MonoBehaviour
{
    [SerializeField] BossData bossData;
    private BossAnimation animator;
    [SerializeField] private Transform pointA;
    [SerializeField] private Transform pointB;
    private float moveSpeed;
    public float restTime;
    public float timeToRest;
    private float timer;
    private Transform currentTarget;
    [SerializeField] private GameObject player;
    private float timeAttack = 1f;
    private bool isHurt = false;
    private BossHealth bossHealth;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.GetChild(0).GetComponent<BossAnimation>();
        bossHealth = GetComponent<BossHealth>();
        moveSpeed = bossData.bossMoveSpeed;
        currentTarget = pointA;
        timer = timeToRest;
    }

    // Update is called once per frame
    void Update()
    {
        if(isHurt == false)
        {
            float distance = transform.position.x - player.transform.position.x;
            if (Mathf.Abs(distance) <= bossData.bossAttackRange)
            {
                timeAttack = 1f;
                animator.AnimAttack();
                if (transform.position.x < player.transform.position.x)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
                else
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
            }
            else
            {
                animator.AnimIdle();
                timeAttack -= Time.deltaTime;
                if (timeAttack <= 0)
                {
                    MoveToPoint();
                }
            }
        }
    }

    void MoveToPoint()
    {
        timer -= Time.deltaTime;
        if(timer <= 0f)
        {
            StartCoroutine(Rest());
        }
        else
        {
            transform.Translate((currentTarget.position - transform.position).normalized * moveSpeed * Time.deltaTime, Space.World);
            animator.AnimWalk();
            if (Vector3.Distance(transform.position, currentTarget.position) < 0.1f)
            {
                currentTarget = (currentTarget == pointB) ? pointA : pointB;
            }
            if (currentTarget == pointB)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    IEnumerator Rest()
    {
        animator.AnimIdle();
        yield return new WaitForSeconds(restTime);
        timer = timeToRest;
    }
    IEnumerator Hurt()
    {
        yield return new WaitForSeconds(0.5f);
        isHurt = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null && collision.gameObject.CompareTag("PlayerAttack"))
        {
            isHurt = true;
            bossHealth.TakenDamage(PlayerHealth.Instance.playerData.playerDamage);
            animator.AnimHurt();
            StartCoroutine(Hurt());
        }
    }
}
