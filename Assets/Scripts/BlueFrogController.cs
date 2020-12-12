using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueFrogController : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D frogBody;

    void Jumped()
    {
        EnemyTools enemyTools = new EnemyTools();

        if (enemyTools.IsPlayerClose(frogBody.transform.position.x))
        {
            // virar o sapo azul na direção do jogador
            // empurrar o pulo do sapo azul na direção do jogador

            if (enemyTools.IsPlayerLeft(frogBody.transform.position.x))
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