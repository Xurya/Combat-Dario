using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletJump : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Rigidbody2D rb = other.gameObject.GetComponent<Rigidbody2D>();
            rb.velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
        }
    }
}
