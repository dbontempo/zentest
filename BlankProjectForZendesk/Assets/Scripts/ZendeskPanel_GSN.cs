using UnityEngine;
using System.Collections;
using ZendeskSDK;

public class ZendeskPanel_GSN : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	/** must include this method for android to behave properly */
	void OnApplicationPause(bool pauseStatus) {
		ZendeskSDK.ZDKConfig.OnApplicationPause (pauseStatus);
	}

	/** must include this method for any zendesk callbacks to work */
	void OnZendeskCallback(string results) {
		ZDKConfig.CallbackResponse (results);
	}

	public void OnShowZendesk() {
		ZendeskSDK.ZDKConfig.Initialize (gameObject); // DontDestroyOnLoad automatically called on your supplied gameObject
		//ZendeskSDK.ZDKConfig.AuthenticateJwtUserIdentity ("<UserId>");
		ZendeskSDK.ZDKConfig.AuthenticateAnonymousIdentity("","","");

		//Add buttons
		AddButtons();
	}

	protected void AddButtons() {
//		AddButton_HelpCenter();
	}
}
