using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathController : MonoBehaviour
{
    public GameObject death;

    void Die()
    {
        GameObject explosion = Instantiate(death, this.transform.position, Quaternion.identity);
        Destroy(explosion, 0.5f);
        Destroy(this.gameObject);
    }
}
