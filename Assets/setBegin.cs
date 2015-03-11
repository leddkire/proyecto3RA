using UnityEngine;
using System.Collections;
using Vuforia;
public class setBegin : MonoBehaviour,ITrackableEventHandler {
	private TrackableBehaviour mTrackableBehaviour;
	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
	}

	public void OnTrackableStateChanged(
		TrackableBehaviour.Status previousStatus,
		TrackableBehaviour.Status newStatus)
	{
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			if(this.transform.childCount <= 0){
				print("ESTA COMENZADO");
			} else {
				print("SE DETECTO ESTA MARCA");
				GameObject ball = GameObject.Find("StartTarget/Sphere");
				GameObject cam = GameObject.Find("ARCamera");
				//Vector3 vec = new Vector3(cam.transform.position.x+this.transform.position.x, cam.transform.position.y+this.transform.position.y, cam.transform.position.z+this.transform.position.z);
				if(ball != null){
					ball.transform.position = this.transform.position;
					ball.transform.rotation = this.transform.rotation;
					ball.transform.parent = cam.transform;
				}
				
			}
		}
		else
		{
			if(previousStatus == TrackableBehaviour.Status.UNKNOWN){
				print("ESTA COMENZANDO");
			} else {
				print ("YA NO ESTA DETECTANDO ESTA MARCA");
			}
		}
	}   
	// Update is called once per frame
	void Update () {
		GameObject ball = GameObject.Find("Sphere");
		GameObject cam = GameObject.Find ("ARCamera");
		Vector3 vec = new Vector3(cam.transform.position.x+ball.transform.position.x, cam.transform.position.y+ball.transform.position.y, cam.transform.position.z+ball.transform.position.z);
		//ball.transform.position = vec;
		Quaternion rot = new Quaternion(cam.transform.rotation.x+ball.transform.rotation.x, cam.transform.rotation.y+ball.transform.rotation.y, cam.transform.rotation.z+ball.transform.rotation.z, cam.transform.rotation.w+ball.transform.rotation.w);
		//ball.transform.rotation = rot;
	}
}
