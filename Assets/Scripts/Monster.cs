using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour {

	public Vector3 velocity = Vector3.zero;
	public bool bullet_enabled = false;
	public int wait_time = 1;
	public int end_time = 10000;
	protected int initial_life = 100;
	protected int life = 100;
	protected int move_timer = 90;
	protected int score = 10000;

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Bullet> ()) {
			Bullet bullet = other.gameObject.GetComponent<Bullet> ();
			if (bullet.isFromPlayer) {
				if (initial_life >= 100) {
					Game_controller.boss_initial_life = initial_life;
					Game_controller.boss_life = life;	
				}
				Destroy(bullet.gameObject);
				life -= 10;
				if (life <= 0) {
					Destroy(gameObject);
					Game_controller.score += score;
				}
			}
		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}
}
