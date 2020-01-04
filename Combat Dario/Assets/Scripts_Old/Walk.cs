using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : MonoBehaviour {

	private Animator anim;

	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	void Update () {
		Movement ();
		{
			float move = Input.GetAxis ("Horizontal");
			anim.SetFloat ("Speed", move);
		}
	}

	void Movement(){
		if(Input.GetKey(KeyCode.D)){
			transform.Translate (Vector2.right * 3f * Time.deltaTime);
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate (-Vector2.right * 3f * Time.deltaTime);
		}
		if (Input.GetKey (KeyCode.W)) {
			transform.Translate (Vector2.up * 6f * Time.deltaTime);
		}
	}
}
