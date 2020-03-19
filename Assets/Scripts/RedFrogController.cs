using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedFrogController : MonoBehaviour
{
    public GameObject fireball;
    public float waitToShoot = 2.0f;

    void Start()
    {
        StartCoroutine(WaitAndShootFireball());
    }

    private IEnumerator WaitAndShootFireball()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitToShoot);
            Instantiate(fireball, this.transform.position, Quaternion.identity);
        }
    }
}
