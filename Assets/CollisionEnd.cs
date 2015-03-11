using UnityEngine;
using System.Collections;

public class CollisionEnd : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collisionInfo){
		if (collisionInfo.collider.name == "endPlane") {
			Application.LoadLevel("gameStart");
		}
	}
}
