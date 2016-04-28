using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	enum inputMethods {Mouse,Keyboard};
	inputMethods currentinput; 
	float min;
	float max;
	float padding = 0.5f;
	float playerShip = 0f;
	public float speed = 12.0f;
	public float laserSpeed = 15f;
	public float fireRate = 0.4f;
	public float health = 450f;
	public GameObject laser;
	void Start () {
		currentinput = inputMethods.Mouse;
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));

		min = leftMost.x + padding;
		max = rightMost.x - padding;
	}

	void Update () {
		if (currentinput == inputMethods.Keyboard) {
			MoveWithKeyboard ();
			if (Input.GetMouseButton (0)) {
				currentinput = inputMethods.Mouse;
			}
		}
		if (currentinput == inputMethods.Mouse) {
			MoveWithMouse ();
			if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)
				|| Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)
				|| Input.GetKeyDown(KeyCode.Space)){
				print("Fuck");
				currentinput = inputMethods.Keyboard;
			}
		}
	}
	void MoveWithKeyboard(){
		float positionX = this.transform.position.x;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			this.transform.position += Vector3.left * speed * Time.deltaTime;
			float posX = Mathf.Clamp(this.transform.position.x,min,max);
			this.transform.position = new Vector2(posX,this.transform.position.y);
			//print (this.transform.position.x);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
			float posX = Mathf.Clamp (this.transform.position.x,min, max);
			this.transform.position = new Vector2 (posX, this.transform.position.y);
			//print (this.transform.position.x);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, fireRate);// here second parameter is not 0 because zero sometime give errors so very very small number.
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ();
		}
	}
	void MoveWithMouse(){
		if (Input.GetMouseButtonDown (0)) {
			InvokeRepeating ("Fire", 0.00000f, fireRate);
		}
		if (Input.GetMouseButtonUp (0)) {
			CancelInvoke ();
		}
		playerShip = Input.mousePosition.x / Screen.width * 13;
		this.transform.position = new Vector2 (Mathf.Clamp(playerShip,min,max), this.transform.position.y);
	}

	void Fire(){
		Vector3 startingPoint = new Vector3 (0, 1, 0) + this.transform.position;
		GameObject laserBeam = Instantiate (laser, startingPoint, Quaternion.identity) as GameObject;
		//laserBeam.GetComponent<Rigidbody2D> ().velocity = new Vector3 (0, 4f,0);
		//Same thing is achieved here by altering the gravity.
	}

	void OnTriggerEnter2D(Collider2D coll){
		EnemyProjectile missile = coll.GetComponent<EnemyProjectile> ();
		if (missile) {
			print ("hit by a projectile");
			missile.Hit ();
			health -= missile.Damage ();
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}
}
