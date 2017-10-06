using UnityEngine;
using System.Collections;

public class Game_controller : MonoBehaviour {

	static public float player_life = 100.0f;
	static public float boss_life = 0;
	static public float boss_initial_life = 100.0f;
	static public int score;
	public GameObject HP_player;
	public GameObject HP_boss;
	public GameObject score_text;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		HP_player.guiTexture.pixelInset = new Rect (-64, -30, (player_life / 100.0f) * 130, 16);
		HP_boss.guiTexture.pixelInset = new Rect (-64, -30, (boss_life / boss_initial_life) * 130, 16);
		score_text.guiText.text = score.ToString();
		if (player_life <= 0) {
			Application.LoadLevel("gameover");
		}
		if (Input.GetKey(KeyCode.G)) {
			player_life = 100111111.0f;
		}
	}
	
}
