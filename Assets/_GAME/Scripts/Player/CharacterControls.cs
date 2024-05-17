using System;
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
    private string defaultLayerName = "Default";
    private int defaultLayerID;
    private string detectLayerName = "DetectCollider";
    private int detectLayerID;
    public bool isDead;
    private bool isDeadSound = true;

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
        defaultLayerID = LayerMask.NameToLayer(defaultLayerName);
        detectLayerID = LayerMask.NameToLayer(detectLayerName);
        Application.targetFrameRate = 60;
        _capsuleCollider2D = GetComponent<CapsuleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        gravityVec = new Vector2(0, -Physics2D.gravity.y);
        MoveDust.Play();
        isMove = true;
    }

    private void Update()
    {
        
        PlayerLevel = PlayerLevelSwitch.instance.CurrentLevel();
        #region Animation
        if (!isDead)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Character.AnimGetDown();
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
            if (_rigidbody2D.velocity.y <= 0)
            {
                _rigidbody2D.velocity -= gravityVec * gravityMulty * Time.deltaTime;
                Character.AnimFalling();
                if (IsGrounded())
                {
                    Character.AnimLanding();
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                Slash();
            }
        }
        else
        {
            StartCoroutine(Dead());
        }
        #endregion
    }

    IEnumerator Dead()
    {
        Character.AnimDead();
        if (isDeadSound)
        {
            AudioManager.instance.Play("Dead");
            isDeadSound = false;
        }
        yield return new WaitForSeconds(1f);
        LBManager.instance.InsertLevel(CenterGameData.instance.GetPlayLevel());
        LBManager.instance.InsertExp(CenterGameData.instance.currentExp);
        GameUIController.instance.SetActivePopup();

    }

    public void SetRank(string val, string rankHash)
    {
        PlayerPrefs.SetString(rankHash, val);
    }

    public void Crawl()
    {
        if(IsGrounded())
        {
            Character.AnimGetDown();
        }
    }

    public void Jump()
    {
        if(IsGrounded())
        {
            AudioManager.instance.Play("Jump");
            Character.AnimJumping();
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, JumpSpeed);
        }
    }

    public void FixedUpdate()
    {
        if(!isDead)
        {
            if(isMove)
            {
                Move();
            }
            else
            {
                MoveBack();
            }
        }
        else
        {
            StopMove();
        }
    }

    private void StopMove()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(PlayerLevel.runSpeed, _rigidbody2D.velocity.y);
    }
    
    private void MoveBack()
    {
        _rigidbody2D.velocity = new Vector2(-PlayerLevel.runSpeed, _rigidbody2D.velocity.y);
    }

    public void Slash()
    {
        if(IsGrounded() && isMove) {
            AudioManager.instance.Play("Slash");
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
                if(!isDead)
                {
                    this.gameObject.layer = detectLayerID;
                    Character.AnimHit();
                    AudioManager.instance.Play("Hurt");
                    StartCoroutine(ReviveCharacter());
                }
            }
        }
    }

    IEnumerator ReviveCharacter()
    {
        isMove = false;
        HPSystemController.instance.ReduceHealth(1);
        yield return new WaitForSeconds(0.2f);
        isMove = true;
        yield return new WaitForSeconds(1f);
        this.gameObject.layer = defaultLayerID;
    }
}