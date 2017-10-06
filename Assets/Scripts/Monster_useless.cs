using UnityEngine;
using System.Collections;

public class Monster_useless : Monster {

	// Use this for initialization
	void Start () {
		life = 10;
		velocity.y = -3.0f;	
	}
	
	// Update is called once per frame
	void Update () {
		if (wait_time > 0) {
			wait_time--;
		}

		if (end_time > 0) {
			end_time--;
		}

		if (wait_time == 0) {
			if (move_timer > 0) {
				move_timer--;
			} else if (end_time != 0) { 
				velocity.y = 0;
			}
			transform.position += velocity * Time.deltaTime;

		}	

		if (end_time == 0) {
			velocity.y = -3.0f;
		}
	}
}
