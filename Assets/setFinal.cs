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
		GameObject cube = GameObject.Find("EndTarget/Cube");
		//GameObject endplane = GameObject.Find("EndTarget/endPlane");
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			//endplane.collider.enabled = false;
			if(cube!=null){
				cube.collider.enabled = false;
			}

		}
		else
		{
			if(previousStatus == TrackableBehaviour.Status.TRACKED){
				if(this.transform.childCount <= 0){
					print("ESTA COMENZADO");
				} else {
					print("SE DETECTO ESTA MARCA");
					GameObject cam = GameObject.Find("ARCamera");
					//Vector3 vec = new Vector3(cam.transform.position.x+this.transform.position.x, cam.transform.position.y+this.transform.position.y, cam.transform.position.z+this.transform.position.z);
					if(cube != null){
						cube.transform.parent = cam.transform;
						//endplane.transform.parent = cam.transform;
						cube.renderer.enabled = true;
						cube.collider.enabled = true;
						//endplane.renderer.enabled = true;
						//endplane.collider.enabled = true;
					}
					
				}
			}
		}
	}   
	// Update is called once per frame
	void Update () {

	}
}
