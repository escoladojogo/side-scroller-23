using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D playerRigidBody;
    public Animator animator;
    public float runBoost = 5;
    public float jumpBoost = 600;
    public CapsuleCollider2D capsuleCollider;
    public GameObject groundTrigger;
    public Text scoreText;
    public LeaderboardController leaderboardUI;
    public Text leaderboardName;
    public GameObject inputNameUI;

    float horizontalMove;
    bool jump;
    Vector3 startPosition;
    bool canClimb;
    bool climb;
    int score;

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

        float verticalMove = Input.GetAxisRaw("Vertical");

        if (verticalMove > 0 && canClimb == true)
        {
            //fazer a raposa subir
            climb = true;
            animator.SetBool("IsClimbing", true);
        }
        else
        {
            climb = false;
            animator.SetBool("IsClimbing", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            jump = true;
            collision.gameObject.SendMessage("Die", gameObject);
        }
        else if (collision.gameObject.tag == "Stairs")
        {
            canClimb = true;
        }
        else if (collision.gameObject.tag == "EndLevelTrigger")
        {
            if (leaderboardUI.IsHighscore(score))
            {
                if (!inputNameUI.activeSelf)
                {
                    inputNameUI.SetActive(true);
                }
            }
            else
            {
                if (!leaderboardUI.gameObject.activeSelf)
                {
                    leaderboardUI.gameObject.SetActive(true);
                }
            }
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Stairs")
        {
            canClimb = false;
        }
    }

    private void FixedUpdate()
    {
        if (climb == true)
        {
            playerRigidBody.velocity = new Vector2(horizontalMove * runBoost, 5);
        }
        else
        {
            playerRigidBody.velocity = new Vector2(horizontalMove * runBoost, playerRigidBody.velocity.y);
        }

        if (jump == true)
        {
            playerRigidBody.AddForce(new Vector2(0, jumpBoost));
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
        capsuleCollider.enabled = false;
        groundTrigger.SetActive(false);

        yield return new WaitForSeconds(1.0f);

        animator.SetBool("IsDying", false);
        transform.position = startPosition;
        capsuleCollider.enabled = true;
        groundTrigger.SetActive(true);
    }

    void LoseALife()
    {
        StartCoroutine(MakePlayerDie());
    }

    void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void SetLeaderboardName()
    {
        leaderboardUI.AddScore(leaderboardName.text, score);
        inputNameUI.SetActive(false);
        leaderboardUI.gameObject.SetActive(true);
    }
}
