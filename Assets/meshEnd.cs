using UnityEngine;
using System;
using TouchScript.Gestures;

public class meshEnd : MonoBehaviour {

	private void OnEnable(){
		GetComponent<LongPressGesture> ().LongPressed += longPressHandler;
	}
	
	private void longPressHandler(object sender, EventArgs e) {
		Debug.Log ("Se presiono mucho el CUBO");
		GameObject obj = GameObject.Find ("ARCamera/Cube");
		if (obj == null) {
			obj = GameObject.Find ("StartTarget/Cube");
			if(obj == null){
				return;
			}
		}
		var target = GameObject.Find ("EndTarget").transform;
		obj.transform.parent = target;
		obj.transform.position = target.transform.position;
		obj.renderer.enabled = false;

		//obj.transform.rotation = new Quaternion (0,0,0,0);
	}

	void Update() {
		//Si se esta moviendo la marca no hay colision

	}
}
