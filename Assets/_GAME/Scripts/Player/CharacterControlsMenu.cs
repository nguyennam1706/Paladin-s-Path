using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControlsMenu : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        _rigidbody2D.velocity = new Vector2(4f, _rigidbody2D.velocity.y);
    }
}
