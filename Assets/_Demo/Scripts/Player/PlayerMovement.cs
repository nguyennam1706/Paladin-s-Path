using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;
    public PlayerData playerData;
    private Rigidbody2D _rb;

    private void Awake()
    {
        if(Instance != null) 
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
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        _rb.velocity = new Vector2(0, playerData.playerJumpForce);
    }

    public void LeftMove()
    {
        _rb.velocity = new Vector2(-playerData.playerMoveSpeed, _rb.velocity.y);
        transform.GetChild(0).transform.localScale = new Vector3(-1, 1, 1);
    }

    public Vector3 FaceTo()
    {
        return transform.GetChild(0).transform.localScale;
    }

    public void RightMove()
    {
        _rb.velocity = new Vector2(playerData.playerMoveSpeed, _rb.velocity.y);
        transform.GetChild(0).transform.localScale = new Vector3(1, 1, 1);
    }
}
