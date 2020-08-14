using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    public Animator animator;
    public float runBoost = 5;
    public float jumpBoost = 600;

    float horizontalMove;
    bool jump;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal");

        if (horizontalMove < 0)
        {
            //raposa olhe para a esquerda
            spriteRenderer.flipX = true;
        }
        else if (horizontalMove > 0)
        {
            //raposa olhe para a direita
            spriteRenderer.flipX = false;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsJumping", false);

        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.SendMessage("Die");
        }
    }

    private void FixedUpdate()
    {
        rigidbody2D.velocity = new Vector2(horizontalMove * runBoost, rigidbody2D.velocity.y);

        if (jump == true)
        {
            rigidbody2D.AddForce(new Vector2(0, jumpBoost));
            jump = false;
        }
    }
}
