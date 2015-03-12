using UnityEngine;
using System.Collections;

public class fixCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GameObject piso = GameObject.Find ("ARCamera/PlanePiso");
		if (piso != null) {	
			piso.transform.rotation=new Quaternion(-this.transform.rotation.x,piso.transform.rotation.y, -this.transform.rotation.z, piso.transform.rotation.w);
		}
	}
}
