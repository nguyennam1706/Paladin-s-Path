using System;
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
    private BoxCollider2D _boxCollider;
    private Rigidbody2D _rigidbody2D;

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
        _boxCollider = GetComponent<BoxCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gravityVec = new Vector2(0, -Physics2D.gravity.y);
        MoveDust.Play();
    }

    private void Update()
    {
        PlayerLevel = PlayerLevelSwitch.instance.CurrentLevel();

        #region Jump, Fall
        if (IsGrounded())
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
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(PlayerLevel.runSpeed, _rigidbody2D.velocity.y);
    }

    public void Slash()
    {
        if(IsGrounded()) {
            Character.AnimSlash();
        }
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision != null)
        {
            if(collision.gameObject.CompareTag("Enemy"))
            {
                CenterGameData.instance.ResetLevel();
            }
        }
    }
}