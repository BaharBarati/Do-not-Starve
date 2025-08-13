using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField]float speed= 1.5f;
    Vector2 input;
    
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        float moveY = 0f;
        if (Input.GetKey(KeyCode.W))
        {
            moveY = 1f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            moveY = -1f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        input = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate()
    {
        // Apply movement
        _rb.MovePosition(_rb.position + input * speed * Time.fixedDeltaTime);
    }

}
    
