using UnityEngine;
using System.Collections;

public class Monster2 : Monster {

	public Bullet bullet1;
	public Bullet bullet2;
	public Bullet bullet3;
	private int bullet_timer;
	private float angle = 0.0f;
	private float radius = 1.0f;

	// Use this for initialization
	void Start () {
		velocity.y = -3.0f;
		life = 1000;
		initial_life = 1000;
		score = 1000000;
	}
	
	// Update is called once per frame
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

			if (bullet_timer == 0 && move_timer == 0 && end_time != 0) {
				angle += Mathf.PI / 23.0f;
				for (int i = 0; i < 3; i++) {
					Vector3 pos = new Vector3(radius * Mathf.Cos(angle + i * 2.0f * Mathf.PI / 3.0f) + transform.position.x, 
					                          radius * Mathf.Sin(angle + i * 2.0f * Mathf.PI / 3.0f) + transform.position.y, 
					                          -2);
					Vector3 vel = new Vector3 (-radius * Mathf.Sin (angle + i * 2.0f * Mathf.PI / 3.0f), 
					                           radius * Mathf.Cos (angle + i * 2.0f * Mathf.PI / 3.0f), 0);
					bullet1.velocity = vel;
					bullet1.parent = this;
					Instantiate(bullet1, pos, transform.rotation);

					pos = new Vector3(radius * Mathf.Cos(Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f) + transform.position.x, 
					                  radius * Mathf.Sin(Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f) + transform.position.y, 
					                  -2);
					vel = new Vector3 (-radius * Mathf.Sin (Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f), 
					                    radius * Mathf.Cos (Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f), 0);
					bullet2.velocity = 2 * vel;
					bullet2.parent = this;
					Instantiate(bullet2, pos, transform.rotation);

					pos = new Vector3(radius * Mathf.Cos(Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f) + transform.position.x, 
					                  radius * Mathf.Sin(Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f) + transform.position.y, 
					                  -2);
					vel = new Vector3 (-radius * Mathf.Sin (Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f), 
					                   radius * Mathf.Cos (Mathf.PI / 12.0f + angle + i * 2.0f * Mathf.PI / 3.0f), 0);
					bullet3.velocity = 3 * vel;
					bullet3.parent = this;
					Instantiate(bullet3, pos, transform.rotation);
				}

				bullet_timer = 2;
			}
		}

		if (end_time == 0) {
			velocity.y = -3.0f;
		}
	}
}
