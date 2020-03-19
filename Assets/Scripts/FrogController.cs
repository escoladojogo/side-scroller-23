using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogController : MonoBehaviour
{
    public float jumpForce = 400f;
    public float waitToJump = 5.0f;
    public Rigidbody2D rigidBody;
    public Animator animator;

    float secondsPassed = 0;

    void Update()
    {
        secondsPassed += Time.deltaTime;

        if (secondsPassed >= waitToJump)
        {
            animator.SetBool("IsJumping", true);
            rigidBody.AddForce(new Vector2(0, jumpForce));
            secondsPassed = 0;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        animator.SetBool("IsJumping", false);
    }

    public bool HasJumped()
    {
        return animator.GetBool("IsJumping") && secondsPassed == 0;
    }
}
