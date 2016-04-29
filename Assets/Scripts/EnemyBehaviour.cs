using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	float projectileSpeed = 5f;
	public float health = 250;
	public float shotsPerSecond = 0.5f;
	public GameObject enemyProjectile;
	ScoreKeeper scoreKeeperObject;
	public AudioClip enemyDestroyAudioClip;

	void OnTriggerEnter2D(Collider2D coll){
		Projectile missile = coll.GetComponent<Projectile> ();
		if (missile) {
			print ("hit by a projectile");
			missile.Hit ();
			health -= missile.Damage ();
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (enemyDestroyAudioClip, this.transform.position);
				Destroy (gameObject);
				scoreKeeperObject.ScoreUpdate ();
			}
		}
	}

	void Start(){
		scoreKeeperObject = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}
	void Update (){
		float probability = Time.deltaTime * shotsPerSecond;
		if (Random.value < probability) { //Because Random.value returns value between 0 and 1.
			Fire ();
		}
	}
	void Fire (){
		Vector3 startPosition = transform.position + new Vector3 (0, - 1f , 0);
		GameObject missile = Instantiate (enemyProjectile,startPosition, Quaternion.identity) as GameObject;
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed);
	}
}
