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
		AudioSource clip = GameObject.Find ("Sphere/hit").audio;
		clip.Play ();
		Debug.Log ("se registro un flick");
		var flick = sender as FlickGesture;
		var vector = flick.ScreenFlickVector;
		GameObject obj = GameObject.Find ("Sphere");
		var sphere = obj.transform;
		
		sphere.GetComponent<Rigidbody> ().AddForce (0, vector.y,-vector.x );
		//Destroy (gameObject);
	}

	private void longPressHandler(object sender, EventArgs e) {
		Debug.Log ("LongPress");
		var press = sender as LongPressGesture;
		GameObject obj = GameObject.Find ("ARCamera/Sphere");
//		GameObject planeRight = GameObject.Find("ARCamera/PlaneRight");
//		GameObject planeLeft = GameObject.Find("ARCamera/PlaneLeft");
		GameObject planePiso = GameObject.Find("ARCamera/PlanePiso");
		var target = GameObject.Find ("StartTarget").transform;
		obj.transform.parent = target;
		obj.transform.position = new Vector3 (0,(float)0.5,0);
		obj.transform.rotation = new Quaternion (0,0,0,0);
		obj.renderer.enabled = false;
//		planeRight.transform.parent = target;
//		planeRight.transform.position = new Vector3 (0,0,-1.25f);
//		//planeRight.transform.rotation = new Quaternion (90,0,0,0);
//		planeRight.renderer.enabled = false;
//		planeLeft.transform.parent = target;
//		planeLeft.transform.position = new Vector3 (0, 0, 1.25f);
//		//planeLeft.transform.rotation = new Quaternion (270,0,0,0);
//		planeLeft.renderer.enabled = false;
		planePiso.transform.parent = target;
		planePiso.transform.position = new Vector3 (0, 0, 0);
		//planePiso.transform.rotation = new Quaternion (0,0,0,0);
		planePiso.renderer.enabled = false;
		//Returns planes

	}
}
