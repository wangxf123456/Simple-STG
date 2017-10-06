using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Bullet bullet;
	private float low_vel = 2.0f;
	private float high_vel = 4.0f;
	private int bullet_timer = 0;

	private Vector3 velocity = Vector3.zero;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (bullet_timer > 0) {
			bullet_timer--;
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			velocity.x = 0;
			if (Input.GetKey(KeyCode.LeftShift)) {
				velocity.y = low_vel;
			} else {
				velocity.y = high_vel;
			}
		} else if (Input.GetKey(KeyCode.DownArrow)) {
			velocity.x = 0;
			if (Input.GetKey(KeyCode.LeftShift)) {
				velocity.y = -low_vel;
			} else {
				velocity.y = -high_vel;
			}			
		} else if (Input.GetKey(KeyCode.LeftArrow)) {
			velocity.y = 0;
			if (Input.GetKey(KeyCode.LeftShift)) {
				velocity.x = -low_vel;
			} else {
				velocity.x = -high_vel;
			}			
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			velocity.y = 0;
			if (Input.GetKey(KeyCode.LeftShift)) {
				velocity.x = low_vel;
			} else {
				velocity.x = high_vel;
			}			
		} else {
			velocity = Vector3.zero;
		}

		if (Input.GetKey(KeyCode.Z) && bullet_timer == 0) {
			Vector3 pos = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.2f, -1);
			Vector3 vel = new Vector3 (0, 4.0f, 0);
			bullet.velocity = vel;
			bullet.isFromPlayer = true;
			Instantiate(bullet, pos, transform.rotation);
			pos = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.2f, 0);
			Instantiate(bullet, pos, transform.rotation);
			bullet_timer = 10;
		}
		transform.position += velocity * Time.deltaTime; 
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.GetComponent<Bullet> ()) {
			Bullet bullet = other.gameObject.GetComponent<Bullet> ();
			if (!bullet.isFromPlayer) {			
				Destroy(bullet.gameObject);
				Game_controller.player_life -= 10;
				if (Game_controller.player_life <= 0) {
					Destroy(gameObject);
				}
			}
		} else if (other.gameObject.GetComponent<Monster> ()) {

			Monster monster = other.gameObject.GetComponent<Monster> ();	
			Destroy(monster.gameObject);
			Game_controller.player_life -= 100;
			Destroy(gameObject);
		}
	}
	
	void OnTriggerStay(Collider other) {
		OnTriggerEnter(other);
	}	
}
