using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    public Rigidbody2D fireballRigidBody;
    public float lifeTime = 3.0f;

    void FixedUpdate()
    {
        fireballRigidBody.MovePosition(new Vector2(transform.position.x - 0.1f, transform.position.y));
        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            //destruir a bola de fogo
            gameObject.SendMessage("Die", gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.SendMessage("LoseALife");
            gameObject.SendMessage("Die", gameObject);
        }
    }

    void AddScore(int score)
    {

    }
}
