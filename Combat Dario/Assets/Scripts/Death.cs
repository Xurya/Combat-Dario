using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}

