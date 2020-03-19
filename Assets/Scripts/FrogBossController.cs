using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogBossController : MonoBehaviour
{
    public BlueFrogController blueFrogController;
    public GameObject fireball;
    public float waitToShoot = 2.0f;
    public GameObject diamond;

    void Start()
    {
        StartCoroutine(WaitAndShootFireballs());
    }

    IEnumerator WaitAndShootFireballs()
    {
        while (true)
        {
            yield return new WaitForSeconds(waitToShoot);

            for (int i = 0; i < 3; i++)
            {
                Instantiate(fireball, this.transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }

        }
    }

    void OnDestroy()
    {
        if (blueFrogController.lives <= 0)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject clone = Instantiate(diamond, this.transform.position, Quaternion.identity);
                clone.SendMessage("JumpRandomly");
            }

            blueFrogController.GetPlayer().SendMessage("EndLevel");
        }
    }
}
