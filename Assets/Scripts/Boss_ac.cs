using UnityEngine;
using System.Collections;

public class Boss_ac : Monster {
	
	public Vector3 start_point;
	public Bullet bullet;
	public float phase;
	public float omega = Mathf.PI;
	private float radius = 1.0f;
	private int bullet_timer = 0;
	// Use this for initialization
	void Start () {
		bullet_enabled = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (bullet_timer > 0) {
			bullet_timer--;
		}
		velocity = new Vector3 (-omega * radius * Mathf.Sin (omega * (Time.time + phase)), 
		                        omega * radius * Mathf.Cos (omega * (Time.time + phase)), 0);
		transform.position += velocity * Time.deltaTime;

		if (bullet_timer == 0) {
			Vector3 vel = new Vector3 (-Mathf.Cos(omega * (Time.time + phase)), 
			                           -Mathf.Sin (omega * (Time.time + phase)), 0);
			bullet.velocity = vel;
			bullet.parent = this;
			Instantiate(bullet, transform.position, transform.rotation);
			bullet_timer = 10;
		}
	}
}
