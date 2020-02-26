using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private GameController gc;

    void Start()
    {
        gc = GameController.instance;   
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gc.lastCheckpointPos = transform.position;
        }
    }
}
