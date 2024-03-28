using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float _dirX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _dirX = Input.GetAxisRaw("Horizontal");
        if(_dirX < 0 )
        {
            PlayerMovement.Instance.LeftMove();
            PlayerAnimation.Instance.AnimRunEnter();
        }
        else if(_dirX > 0 )
        {
            PlayerMovement.Instance.RightMove();
            PlayerAnimation.Instance.AnimRunEnter();
        }
        else
        {
            PlayerAnimation.Instance.AnimRunExit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerMovement.Instance.Jump();
        }
    }
}
