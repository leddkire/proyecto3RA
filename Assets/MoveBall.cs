using System;
using TouchScript.Gestures;
using UnityEngine;

public class MoveBall : MonoBehaviour {
	private void OnEnable(){
		Debug.Log ("Se creo el enable");
		GetComponent<FlickGesture>().Flicked += flickedHandler;
		GetComponent<LongPressGesture> ().LongPressed += longPressHandler;
	}
	
	private void flickedHandler(object sender, EventArgs e){
		Debug.Log ("se registro un flick");
		var flick = sender as FlickGesture;
		var vector = flick.ScreenFlickVector;
		GameObject obj = GameObject.Find ("Sphere");
		var sphere = obj.transform;
		
		sphere.GetComponent<Rigidbody> ().AddForce (vector.y, 0,-vector.x );
		//Destroy (gameObject);
	}

	private void longPressHandler(object sender, EventArgs e) {
		Debug.Log ("LongPress");
		var press = sender as LongPressGesture;
		GameObject obj = GameObject.Find ("ARCamera/Sphere");
		obj.transform.parent = GameObject.Find ("StartTarget").transform;
		obj.transform.position = new Vector3 (0,(float)0.5,0);
		obj.transform.rotation = new Quaternion (0,0,0,0);
	}
}
