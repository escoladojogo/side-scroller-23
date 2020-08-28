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
    Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
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
        if (collision.gameObject.tag == "Enemy")
        {
            jump = true;
            collision.gameObject.SendMessage("Die");
        }
        else
        {
            animator.SetBool("IsJumping", false);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(MakePlayerDie());
        }
    }

    IEnumerator MakePlayerDie()
    {
        jump = true;
        animator.SetBool("IsDying", true);

        yield return new WaitForSeconds(1.0f);

        animator.SetBool("IsDying", false);
        transform.position = startPosition;
    }
}
