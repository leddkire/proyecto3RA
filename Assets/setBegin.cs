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
		GameObject ball = GameObject.Find("StartTarget/Sphere");
//		GameObject planeRight = GameObject.Find("StartTarget/PlaneRight");
//		GameObject planeLeft = GameObject.Find("StartTarget/PlaneLeft");
		GameObject planePiso = GameObject.Find("StartTarget/PlanePiso");
		if (newStatus == TrackableBehaviour.Status.DETECTED ||
		    newStatus == TrackableBehaviour.Status.TRACKED ||
		    newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)
		{
			//Puede que reparenting aqui
			/*ball.collider.enabled = false;
			planeLeft.collider.enabled = false;
			planeRight.collider.enabled = false;
			planePiso.collider.enabled = false;*/
			GameObject cubo = GameObject.Find("ARCamera/Cube");
			if(cubo != null){
				var heading = cubo.transform.position - this.transform.position;
				cubo.transform.parent = this.transform;
				cubo.transform.position = new Vector3(this.transform.position.x, heading.y, heading.z);
				print(heading.x);
				print (heading.y);
			}
		}
		else
		{
			if(previousStatus == TrackableBehaviour.Status.TRACKED){
				if(this.transform.childCount <= 0){
					print("ESTA COMENZADO");

				} else {
					print("SE DETECTO ESTA MARCA");


				}
					
			}
		}
	}
 
	// Update is called once per frame
	void Update () {
	}
}
