using UnityEngine;
using System.Collections;
using Vuforia;
public class setFinal : MonoBehaviour,ITrackableEventHandler {
	Vector3 v;
	private TrackableBehaviour mTrackableBehaviour;
	// Use this for initialization
	void Start () {
		mTrackableBehaviour = GetComponent<TrackableBehaviour>();
		if (mTrackableBehaviour)
		{
			mTrackableBehaviour.RegisterTrackableEventHandler(this);
		}
		v = this.transform.position;
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
				GameObject cube = GameObject.Find("EndTarget/Cube");
				GameObject cam = GameObject.Find("ARCamera");
				//Vector3 vec = new Vector3(cam.transform.position.x+this.transform.position.x, cam.transform.position.y+this.transform.position.y, cam.transform.position.z+this.transform.position.z);
				if(cube != null){
					cube.transform.position = this.transform.position;
					cube.transform.rotation = this.transform.rotation;
					cube.transform.parent = cam.transform;
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

	}
}
