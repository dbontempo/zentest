using UnityEngine;
using System.Collections;

public class FeedbackScript : MonoBehaviour {
	private GameObject zendeskObject;

	//if feature flag and device.
	public void OnFeedbackPress() {
		Debug.Log("---- OnFeedbackPress");


		//TODO Check for feature flag.

		//TODO Check for device. Android minimum version.

		//Check for Zendesk object in scene.
		zendeskObject = GameObject.Find("ZendeskObject");
		if(zendeskObject == null) {
			Debug.Log("---- Zendobject is null.");
			//Create zendobject
			zendeskObject = new GameObject("ZendeskObject");
			zendeskObject.AddComponent<ZendeskTester>();
		} else {
			Debug.Log("---- Zendobject exists in scene.");
//			zendeskObject.GetComponent<ZendeskTester>().CallShowHelpCenter();
		}
	}
}
