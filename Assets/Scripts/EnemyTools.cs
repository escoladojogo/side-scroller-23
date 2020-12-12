using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTools
{
    GameObject player;

    public EnemyTools()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool IsPlayerClose(float enemyX)
    {
        float diffX = Mathf.Abs(player.transform.position.x - enemyX);

        if (diffX <= 10)
        {
            return true;
        }

        return false;
    }

    public bool IsPlayerLeft(float enemyX)
    {
        if (player.transform.position.x < enemyX)
        {
            return true;
        }

        return false;
    }
}
