﻿using System;
using System.Collections;
using UnityEngine;


public class CharacterControls : MonoBehaviour
{
    public static CharacterControls instance;
    public Character Character;
    public ParticleSystem MoveDust;
    public PlayerLevel PlayerLevel;

    #region Jump
    [Header("JumpSystem")]
    [SerializeField] private float JumpSpeed = 5f;
    [SerializeField] private float gravityMulty;
    private Vector2 gravityVec;
    [SerializeField] private LayerMask jumpableGround;
    #endregion
    private CapsuleCollider2D _capsuleCollider2D;
    private Rigidbody2D _rigidbody2D;
    private bool isMove;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("Only 1 instance " + gameObject.name);
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gravityVec = new Vector2(0, -Physics2D.gravity.y);
        MoveDust.Play();
        isMove = true;
    }

    private void Update()
    {
        Debug.Log(IsGrounded());
        PlayerLevel = PlayerLevelSwitch.instance.CurrentLevel();

        #region Jump, Fall
        if (IsGrounded() && Input.GetKeyDown(KeyCode.DownArrow))
        {
            Character.AnimGetDown();
        }

        if(IsGrounded())
        {
            Character.AnimLanding();
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }
        if (_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity -= gravityVec * gravityMulty * Time.deltaTime;
            Character.AnimFalling();
        }
        #endregion


    }

    private void Jump()
    {
        Character.AnimJumping();
        _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, JumpSpeed);
    }

    public void FixedUpdate()
    {
        if(isMove)
        {
            Move();
        }
        else
        {
            StopMove();
        }
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(PlayerLevel.runSpeed, _rigidbody2D.velocity.y);
    }
    
    private void StopMove()
    {
        _rigidbody2D.velocity = new Vector2(-PlayerLevel.runSpeed, _rigidbody2D.velocity.y);
    }

    public void Slash()
    {
        if(IsGrounded() && isMove) {
            Character.AnimSlash();
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.Raycast(_capsuleCollider2D.bounds.center, Vector2.down, _capsuleCollider2D.bounds.extents.y + .1f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Trap"))
            {
                Character.AnimHit();
                StartCoroutine(ResetCharacter());
            }
        }
    }

    IEnumerator ResetCharacter()
    {
        isMove = false;
        CenterGameData.instance.ResetLevel();
        CenterGameData.instance.ResetExp();
        yield return new WaitForSeconds(0.5f);
        isMove = true;
    }
}