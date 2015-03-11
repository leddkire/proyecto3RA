using System;
using TouchScript.Gestures;
using UnityEngine;

public class MoveBall : MonoBehaviour {
	private void OnEnable(){
		GetComponent<FlickGesture>().Flicked += flickedHandler;
	}
	
	private void flickedHandler(object sender, EventArgs e){
		var flick = sender as FlickGesture;
		var vector = flick.ScreenFlickVector;
		GameObject obj = GameObject.Find ("Sphere");
		var sphere = obj.transform;
		
		sphere.GetComponent<Rigidbody> ().AddForce (0, vector.y, vector.x);
		//Destroy (gameObject);
	}
}
