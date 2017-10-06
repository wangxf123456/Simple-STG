using UnityEngine;
using System.Collections;

public class Monster1 : Monster {

	public GameObject bullet;
	public GameObject beam1, beam2;
	public Boss_ac boss_ac;
	private int bullet_timer, beam1_timer, beam2_timer, beam_wait_timer;
	private bool is_beam1, is_ac = true;
	private float angle = 0.0f;
	private float radius = 5.0f;

	// Use this for initialization
	void Start () {
		velocity.y = -3.0f;
		beam1_timer = 2;
		beam2_timer = 2;
		beam_wait_timer = 0;
		is_beam1 = true;
		life = 1000;
		score = 10000000;
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
				if (is_ac) {
					Vector3 pos = new Vector3(transform.position.x + 3f, transform.position.y, -1);
					Instantiate(boss_ac, pos, transform.rotation);	
					is_ac = false;
				}
			}
			transform.position += velocity * Time.deltaTime;

			if (beam_wait_timer > 0) {
				beam_wait_timer--;
			}

			if (is_beam1 && beam1_timer > 0) {
				beam1_timer--;
			}

			if (!is_beam1 && beam2_timer > 0) {
				beam2_timer--;
			}

			if (move_timer == 0 && end_time != 0 && beam_wait_timer == 0 && is_beam1 && beam1_timer == 0 && angle <= 2 * Mathf.PI) {
				Vector3 pos = new Vector3(radius * Mathf.Cos(angle) + transform.position.x, 
				                          radius * Mathf.Sin(angle) + transform.position.y, 
				                          transform.position.z);
				Quaternion rot = Quaternion.Euler(0, 0, angle * 180 / Mathf.PI + 90);
				angle += Mathf.PI / 12.0f;
				Destroy(Instantiate(beam1, pos, rot), 2.0f);
				beam1_timer = 2;
				if (angle >= 2 * Mathf.PI) {
					is_beam1 = false;
					angle = -Mathf.PI / 24.0f;
				}
			}

			if (move_timer == 0 && end_time != 0 && beam_wait_timer == 0 && !is_beam1 && beam2_timer == 0 && angle >= -2 * Mathf.PI) {
				Vector3 pos = new Vector3(radius * Mathf.Cos(angle) + transform.position.x, 
				                          radius * Mathf.Sin(angle) + transform.position.y, 
				                          transform.position.z);
				Quaternion rot = Quaternion.Euler(0, 0, angle * 180 / Mathf.PI + 90);
				angle -= Mathf.PI / 12.0f;
				Destroy(Instantiate(beam2, pos, rot), 2.0f);
				beam2_timer = 2;
				if (angle <= -2 * Mathf.PI) {
					is_beam1 = true;
					angle = 0.0f;
					beam_wait_timer = 240;
				}
			}
		}

		if (end_time == 0) {
			velocity.y = -3.0f;
		}
	}
}
