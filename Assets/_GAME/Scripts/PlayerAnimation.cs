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
}
