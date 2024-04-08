using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    public static PlayerAnimation Instance;
    private Animator _animator;
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
        _animator = GetComponent<Animator>();
    }

    public void AnimRunEnter()
    {
        if (_animator != null)
        {
            _animator.SetBool("isRunning", true);
        }
    }
    public void AnimRunExit()
    {
        if (_animator != null)
        {
            _animator.SetBool("isRunning", false);
        }
    }
    public void AnimAttack()
    {
        if (_animator != null)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")) return;
            _animator.SetTrigger("isAttacking");
            //PlayerHealth.Instance.SkillMana(3f);
        }
    }
    public void AnimSkill ()
    {
        if (_animator != null)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Skill")) return;
            _animator.SetTrigger("isSkill");
            PlayerHealth.Instance.SkillMana(20f);
        }
    }
    public void AnimJumpEnter()
    {
        if (_animator != null)
        {
            _animator.SetTrigger("isJumping");
        }
    }

    public void AnimCroush()
    {
        if (_animator != null)
        {
            if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Croush")) return;
            _animator.SetTrigger("isCroushing");
        }
    }
}
