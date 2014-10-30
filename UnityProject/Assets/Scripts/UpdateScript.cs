using UnityEngine;
using System.Collections;

public class UpdateScript : MonoBehaviour {
	
	void Update () {
		if(Input.GetButtonDown("Pause")) {
			if(Time.timeScale > 0.0f)
			{
				Time.timeScale = 0.0f;
				AudioListener.pause = true;
				this.gameObject.AddComponent("PauseMenuScript");
			}
			else
			{
				Time.timeScale = 1.0f;
				AudioListener.pause = false;
				Destroy(GetComponent<PauseMenuScript>());
			}
		}
	}
}
