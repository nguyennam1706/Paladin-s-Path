using System;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Character : Creature
{
    private Animator animator;
    private const string Player_Jumping = "Jumping";
    private const string Player_Dead = "Dead";
    private const string Player_Heal = "Heal";
    private const string Player_Hit = "Hit";
    private const string Player_GetDown = "GetDown";
    private const string Player_GetUp = "GetUp";
    private const string Player_Slash = "Slash";
    private const string Player_Falling = "Falling";

    private void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    
    public void AnimGetDown()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(Player_GetDown)) return;
        if(animator.GetCurrentAnimatorStateInfo(0).IsName("Crawling")) return;
        animator.SetTrigger(Player_GetDown);
    }
    public void AnimHeal()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(Player_Heal)) return;
        animator.SetTrigger(Player_Heal);
    }
    public void AnimHit()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(Player_Hit)) return;
        animator.SetTrigger(Player_Hit);
    }
    public void AnimSlash()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(Player_Slash)) return;
        animator.SetTrigger(Player_Slash);
    }
    public void AnimGetUp()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName(Player_GetUp)) return;
        animator.SetTrigger(Player_GetUp);
    }
    public void AnimDead()
    {
        animator.SetBool(Player_Dead, true);
    }
    public void AnimJumping()
    {
        animator.SetBool(Player_Jumping, true);
    }
    public void AnimFalling()
    {
        animator.SetBool(Player_Jumping, false);
        animator.SetBool(Player_Falling, true);
    }
    public void AnimLanding()
    {
        animator.SetBool(Player_Falling, false);
    }
    
}