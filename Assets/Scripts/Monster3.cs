using UnityEngine;
using System.Collections;

public class Monster3 : Monster {

	private float bullet_num = 72.0f;
	public Bullet bullet1;
	public Bullet bullet2;
	private int bullet_timer = 0, bullet_timer2 = 0;
	private int round_timer = 180;
	private float angle = 0.0f;
	private float radius = 1.0f;
	private GameObject player;

	// Use this for initialization
	void Start () {
		velocity.y = -3.0f;
		life = 1000;
		initial_life = 1000;
		score = 1000000;	
		player = GameObject.FindWithTag("Player");
	}
	
	void FixedUpdate () {
		
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
				bullet_enabled = true;
			}
			transform.position += velocity * Time.deltaTime;
			
			if (bullet_timer > 0 && move_timer == 0) {
				bullet_timer--;
			}

			if (bullet_timer2 > 0 && move_timer == 0) {
				bullet_timer2--;
			}

			if (round_timer > 0 && move_timer == 0) {
				round_timer--;
			}

			if (round_timer == 0) {
				round_timer = 180;
			}

			if (round_timer > 60 && bullet_timer == 0 && move_timer == 0 && end_time != 0) {
				for (int i = 0; i < bullet_num; i++) {
					Vector3 pos = new Vector3(radius * Mathf.Cos(2 * i * Mathf.PI / bullet_num) + transform.position.x, 
					                          radius * Mathf.Sin(2 * i * Mathf.PI / bullet_num) + transform.position.y, 
					                          -2);
					Vector3 vel = new Vector3 (radius * Mathf.Cos (2 * i * Mathf.PI / bullet_num), 
					                           radius * Mathf.Sin (2 * i * Mathf.PI / bullet_num), 0);
					bullet1.velocity = vel;
					bullet1.parent = this;
					Instantiate(bullet1, pos, transform.rotation);
				}				
				bullet_timer = 15;
			}

			if (bullet_timer2 == 0) {
				Vector3 pos = player.transform.position;
				Vector3 vel = (pos - transform.position) / 1.5f;
				bullet2.velocity = vel;
				bullet2.parent = this;
				Instantiate(bullet2, transform.position, transform.rotation);
				bullet_timer2 = 60;				
			}
		}
		
		if (end_time == 0) {
			velocity.y = -3.0f;
		}
	}
}
