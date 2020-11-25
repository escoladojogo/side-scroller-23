using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFrogController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D frogBody;

    void Jumped()
    {
        GameObject player = GameObject.FindWithTag("Player");

        float diffX = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (diffX <= 10)
        {
            // virar o sapo azul na direção do jogador
            // empurrar o pulo do sapo azul na direção do jogador

            if (player.transform.position.x < transform.position.x)
            {
                //jogador está na esquerda
                spriteRenderer.flipX = false;
                frogBody.AddForce(new Vector2(-100, 0));
            }
            else
            {
                //jogador está na direita
                spriteRenderer.flipX = true;
                frogBody.AddForce(new Vector2(100, 0));
            }
        }
    }
}