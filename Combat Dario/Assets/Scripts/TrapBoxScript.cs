using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapBoxScript : MonoBehaviour {
	void OnCollisionEnter2D(Collision2D obj){
		if (obj.collider.gameObject.tag == "Player") {
			GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
