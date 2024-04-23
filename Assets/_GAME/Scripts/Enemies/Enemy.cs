using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Creature
{
    private Animator animator;
    private const string Enemy_Dead = "Dead";
    private const string Enemy_Hit = "Hit";

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    public void AnimHit()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(Enemy_Hit)) return;
        animator.SetTrigger(Enemy_Hit);
    }
    public void AnimDead()
    {
        animator.SetBool(Enemy_Dead, true);
    }
}
