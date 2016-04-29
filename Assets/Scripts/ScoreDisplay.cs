using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<Text> ().text = "Your Score : " + ScoreKeeper.score;
		ScoreKeeper.Reset ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
