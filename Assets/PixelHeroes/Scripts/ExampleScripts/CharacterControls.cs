using System;
using UnityEngine;


public class CharacterControls : MonoBehaviour
{
    public static CharacterControls instance;
    public Character Character;
    public ParticleSystem MoveDust;
    private PlayerLevel PlayerLevel;

    #region Jump
    [Header("JumpSystem")]
    [SerializeField] private float JumpSpeed = 5f;
    [SerializeField] private ParticleSystem JumpDust;
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
        PlayerLevel = PlayerLevelSwitch.instance.CurrentLevel();
    }

    private void Update()
    {
        #region Jump, Fall
        if (IsGrounded())
        {
            Character.AnimLanding();
        }
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            Jump();
        }

        if(_rigidbody2D.velocity.y < 0)
        {
            _rigidbody2D.velocity -= gravityVec * gravityMulty * Time.deltaTime;
            Character.AnimFalling();
        }
        #endregion

        if (Input.GetKeyDown(KeyCode.S) && IsGrounded()) Character.AnimSlash();
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

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}