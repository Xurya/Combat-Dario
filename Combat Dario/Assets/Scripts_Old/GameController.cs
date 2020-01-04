using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public RawImage victory;
    public Text taunt;
    public Button restart, exit, next;
	public string scene1 = "Part1";
	public string scene2 = "Part2";

    private void Start()
    {
		if (scene2 != scene1) {
			next.gameObject.SetActive (false);
		}
        victory.enabled = false;
        taunt.enabled = false;
        restart.gameObject.SetActive(false);
        exit.gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("End"))
        {
            victory.enabled = true;
            taunt.enabled = true;
            restart.gameObject.SetActive(true);
            exit.gameObject.SetActive(true);
			if (scene1 != scene2) {
				next.gameObject.SetActive (true);
			}
            GameObject.Find("Character").GetComponent<Walk>().enabled = false;
        }
    }

    public void Restart()
    {
		SceneManager.LoadScene(scene1);
    }

	public void Next(){
		SceneManager.LoadScene (scene2);
	}

    public void exitGame()
    {
        Application.Quit();
    }
}
