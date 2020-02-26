using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    public Dialogue dialogue;
    public int type = 0;
    public bool destroy = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (type == 1 && collision.gameObject.CompareTag("Player"))
        {
            TriggerDialogue();
            if (destroy)
            {
                Destroy(this.gameObject);
            }
        }
    }

    public void TriggerDialogue ()
    {
        //Replace with Singleton.
        DialogueManager.instance.StartDialogue(dialogue);
    }
}
