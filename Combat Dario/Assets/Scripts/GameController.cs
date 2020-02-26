using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }
    public Vector2 lastCheckpointPos;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        }
    }


}
