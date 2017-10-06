using UnityEngine;
using System.Collections;

public class Monster_small1 : Monster {

	public Bullet bullet;
	private int bullet_timer = 0;
	private float angle = 0.0f;
	private float radius = 1.0f;
	private GameObject player;

	// Use this for initialization
	void Start () {
		velocity.y = -3.0f;
		score = 100000;
		player = GameObject.FindWithTag("Player");
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

			if (bullet_timer > 0) {
				bullet_timer--;
			}

			if (bullet_timer == 0 && move_timer == 0 && end_time != 0 && angle <= 2 * Mathf.PI) {
				Vector3 pos = new Vector3(radius * Mathf.Cos(angle) + transform.position.x, 
				                          radius * Mathf.Sin(angle) + transform.position.y, 
				                          -2);
				angle += Mathf.PI / 12.0f;
				bullet.velocity = new Vector3 (radius * Mathf.Cos (angle), 
				                               radius * Mathf.Sin (angle), 0);
				bullet.parent = this;
				Instantiate(bullet, pos, transform.rotation);
				bullet_timer = 2;
			}

			if (angle > 2 * Mathf.PI) {
				bullet_enabled = true;
				if (bullet_timer == 0) {
					Vector3 pos = player.transform.position;
					Vector3 vel = (pos - transform.position);
					bullet.velocity = vel;
					bullet.parent = this;
					Instantiate(bullet, transform.position, transform.rotation);
					bullet_timer = 60;				
				}
			}
		}

		if (end_time == 0) {
			velocity.y = -3f;
		}
	}
}
