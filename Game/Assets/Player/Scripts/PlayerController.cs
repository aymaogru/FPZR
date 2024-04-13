using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Vector2 direction;
    private Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    
    }

    void Update()
    {
        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");

        animator.SetBool("IsMove", direction != Vector2.zero);
        if(direction.x != 0){
            spriteRenderer.flipX = direction.x == -1;
        }
        
    }

    void FixedUpdate(){
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);
    }
    
}
