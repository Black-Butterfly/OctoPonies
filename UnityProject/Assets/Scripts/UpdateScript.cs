using UnityEngine;
using System.Collections;

public class UpdateScript : MonoBehaviour {
	
	void Update () {
		if(Input.GetButtonDown("Pause")) {
			if(Time.timeScale > 0.0f)
			{
				Time.timeScale = 0.0f;
				this.gameObject.AddComponent("PauseMenuScript");
			}
			else
			{
				Time.timeScale = 1.0f;
				Destroy(GetComponent<PauseMenuScript>());
			}
		}
	}
}
