using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {


	enum inputMethods {Mouse,Keyboard};
	inputMethods currentinput; 
	float min;
	float max;
	float padding = 0.5f;
	float playerShip = 0f;
	float speed = 12.0f;
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
				|| Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)){
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
			print (this.transform.position.x);
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			this.transform.position += Vector3.right * speed * Time.deltaTime;
			float posX = Mathf.Clamp (this.transform.position.x,min, max);
			this.transform.position = new Vector2 (posX, this.transform.position.y);
			print (this.transform.position.x);
		}
	}
	void MoveWithMouse(){
		playerShip = Input.mousePosition.x / Screen.width * 13;
		this.transform.position = new Vector2 (Mathf.Clamp(playerShip,min,max), this.transform.position.y);
	}
}
