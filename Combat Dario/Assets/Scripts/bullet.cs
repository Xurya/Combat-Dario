using UnityEngine;
using UnityEngine.SceneManagement;

public class bullet : MonoBehaviour
{
    [Header("Properties")]
    public float speed = 1f;
    public float life = 10f;

    void Start()
    {
        Quaternion quat = this.transform.rotation;
        Vector3 rot = quat.eulerAngles;
        float rotation = rot[2];
        rotation = Mathf.Deg2Rad * rotation;
        Vector2 direction = new Vector2(Mathf.Cos(rotation), Mathf.Sin(rotation));
        Rigidbody2D rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = direction * -speed;
    }

    void Update()
    {
        life -= Time.deltaTime;
        if(life < 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D obj)
    {
        if (obj.gameObject.tag != "Player")
        {
            //Add destroy animation?
            //Destroy(obj.gameObject);
            Destroy(gameObject);
        }
    }
}
