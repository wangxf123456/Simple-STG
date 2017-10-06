using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

	public Vector3 velocity = Vector3.zero;
	public bool isFromPlayer = false;
	public Monster parent = null;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if ((!isFromPlayer && parent.bullet_enabled) || isFromPlayer) {
			transform.position += velocity * Time.deltaTime;
		}
		if (transform.position.x <= -5 || transform.position.x >= 4 || 
		    transform.position.y >= 7 || transform.position.y <= -5) {
			Destroy(gameObject);
		}
	}

}
