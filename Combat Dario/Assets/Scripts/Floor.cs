using UnityEngine;
using UnityEngine.SceneManagement;

public class Floor : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.collider.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        } else
        {
            Destroy(obj.collider.gameObject);
        }
    }
}