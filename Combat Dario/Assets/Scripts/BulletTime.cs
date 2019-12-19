using UnityEngine;

public class BulletTime : MonoBehaviour
{
    public static int DEFAULT_LAYER = 0;

    [Header("Settings")]
    public bool bulletTime = false;
    public int layerToggle = 9;
    public int duration = 0;
    public int cooldown = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Toggle();
        }
    }

    public void Toggle()
    {
        bulletTime = !bulletTime;
        if (bulletTime)
        {
            this.gameObject.layer = layerToggle;
        }
        else
        {
            this.gameObject.layer = DEFAULT_LAYER;
        }
    }
}
