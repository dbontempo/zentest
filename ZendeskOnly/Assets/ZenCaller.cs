using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ZenCaller : MonoBehaviour {
	protected GameObject zendeskObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnStartZen() {
		Debug.Log("OnStartZen");
		if(zendeskObject == null) {
			Debug.Log("OnStartZen.rcreate it.");
			// Create object
			zendeskObject = new GameObject("zendeskObject");

			//Attach script.
			zendeskObject.AddComponent<ZendeskTester>();
			//Add to scene (stage)
//			gameObject.AddComponent<GameObject>()
		}
	}

//	public void OnChangeLevel2() {
//		SceneManager.LoadScene("level2");
//	}
//	public void OnChangeLevel1() {
//		SceneManager.LoadScene("ZenScene");
//	}
}
