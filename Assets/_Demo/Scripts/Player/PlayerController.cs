using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private BoxCollider2D _boxCollider;
    [SerializeField] private LayerMask jumpableGround;
    private float _dirX;
    private PlayerAnimation _anim;
    private PlayerMovement _move;
    [SerializeField] private GameObject bullet;
    [SerializeField] private GameObject bulletSpawnPos;
    private bool isSkill = false;
    // Start is called before the first frame update
    void Start()
    {
        _boxCollider = GetComponent<BoxCollider2D>();
        _anim = PlayerAnimation.Instance;
        _move = PlayerMovement.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        if(_dirX < 0 )
        {
            _move.LeftMove();
            _anim.AnimRunEnter();
        }
        else if(_dirX > 0 )
        {
            _move.RightMove();
            _anim.AnimRunEnter();
        }
        else
        {
            _anim.AnimRunExit();
        }

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            _move.Jump();
            StartCoroutine(JumpAction());
        }

        if(Input.GetMouseButtonDown(0) && IsGrounded())
        {
            _anim.AnimAttack();
        }
        if(Input.GetMouseButtonDown(1) && IsGrounded() && PlayerHealth.Instance.isManaZero == false && isSkill == false)
        {
            _anim.AnimSkill();
            StartCoroutine(SkillDelay());
        }

        if (Input.GetKeyDown(KeyCode.S) && IsGrounded())
        {
            _anim.AnimCroush();
        }

    }

    IEnumerator SkillDelay()
    {
        isSkill = true;
        yield return new WaitForSeconds(0.5f);
        var bulletSp = Instantiate(bullet, bulletSpawnPos.transform.position, transform.rotation);
        if (bulletSp.transform.localScale.x < 0)
        {
            bulletSp.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 0);
        }
        else
        {
            bulletSp.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
        }
        bulletSp.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        isSkill = false;
    }

    public bool IsGrounded()
    {
        return Physics2D.BoxCast(_boxCollider.bounds.center, _boxCollider.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }

    IEnumerator JumpAction()
    {
        _anim.AnimJumpEnter();
        yield return new WaitForSeconds(0.8f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.CompareTag("BossAttack"))
        {
            
        }
    }
}
