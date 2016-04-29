using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text scoreUIText;
	public static int score = 0;
	// Use this for initialization
	void Start () {
		scoreUIText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void ScoreUpdate(){
		print ("score updated");
		score += 100;
		scoreUIText.text = "Score : " + score;
	}
	public void Die(){
		scoreUIText.text = "Score : " + score;
	}
	public static void Reset(){
		score = 0;
	}
}
