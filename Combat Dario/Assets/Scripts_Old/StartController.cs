using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartController : MonoBehaviour {
    public void Play()
    {
        SceneManager.LoadScene("Part1");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
