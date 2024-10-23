using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed;
    private float xInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        Movement();
    }
    private void Movement(){
        rb.velocity = new Vector2(xInput * moveSpeed, rb.velocity.y);
    }
}
