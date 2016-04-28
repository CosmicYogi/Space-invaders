using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	public float speed = 1;
	public GameObject enemyPrefab;
	float center;
	float min;
	float max;
	float padding = 0.5f;
	Vector3 worldPointCoordinates;
	public Vector3 boxCenter;
	public float width = 10;
	public float height = 5;
	bool movingRight = true;
	// Use this for initialization
	void Start () {
		Vector3 distance = this.transform.position - Camera.main.transform.position;
		distance.x = Mathf.Abs (distance.x);
		worldPointCoordinates = Camera.main.ViewportToWorldPoint (new Vector3 (0.5f, 0.5f, distance.x));
		center = worldPointCoordinates.x; // 

		min = Camera.main.ViewportToWorldPoint (new Vector3 (0f, 0f, distance.x)).x + padding;
		max = Camera.main.ViewportToWorldPoint (new Vector3 (1f, 0f, distance.x)).x - padding ;
		print (min + " and " + max);

		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab, child.transform.position , Quaternion.identity) as GameObject;
			enemy.transform.parent = child;
		}
	}

	void OnDrawGizmos(){
		Gizmos.DrawWireCube (boxCenter, new Vector3 (width, height, 0));
	}
	// Update is called once per frame
	void Update () {

		foreach (Transform child in transform) {
			if (child.transform.position.x >= max) {
				movingRight = false;
			} else if (child.transform.position.x <= min) {
				movingRight = true;
			}
		}

		switch (movingRight) {
		case true:
			MoveRight ();
			break;

		case false:
			MoveLeft ();
			break;
		}
			
	}

	void MoveLeft(){
		// For moving left.
		transform.position -= new Vector3 (speed * Time.deltaTime, 0f, 0f); 
	}
	void MoveRight(){
		//For moving right.
		transform.position += new Vector3 (speed * Time.deltaTime, 0f, 0f);
	}
}
