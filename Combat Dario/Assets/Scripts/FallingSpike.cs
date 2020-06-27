using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingSpike : MonoBehaviour {
    [Header("Properties")]
	private Rigidbody2D rb;
	private PolygonCollider2D collider;
	public float gravity = 5;
	public int tickCount = 0;
	public bool selfDel = false;
	public float lifespan = .5f;

	void Start(){
		rb = GetComponent<Rigidbody2D> ();
		collider = GetComponent<PolygonCollider2D> ();
	}

	void Update(){
		RaycastHit2D hit = Physics2D.Raycast (transform.position, Vector2.down);
		if (hit.collider != null && hit.collider.gameObject.tag == "Player") {
			if (tickCount <= 0) {
				rb.gravityScale = gravity;
				if (selfDel) {
					Destroy (this.gameObject, lifespan);
				}
			} else {
				tickCount--;
			}
		}
	}
}
