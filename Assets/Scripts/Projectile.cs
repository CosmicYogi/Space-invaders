using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	public float dodamage = 100f;

	public void Hit(){
		Destroy (gameObject);
	}
	public float Damage (){
		return dodamage;
	}
}
