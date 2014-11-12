using UnityEngine;
using System.Collections;

public class UpdateScript : MonoBehaviour {

	void Update () {
		if(Input.GetButtonDown("Pause")) {
			if(Time.timeScale > 0.0f)
			{
				Time.timeScale = 0.0f;
				AudioListener.pause = true;
				this.transform.GetChild(0).gameObject.SetActive(true);
				this.transform.GetChild(0).gameObject.AddComponent<PauseMenuScript>();
			}
			else
			{
				Time.timeScale = 1.0f;
				AudioListener.pause = false;
				this.transform.GetChild(0).gameObject.SetActive(false);
				Destroy(this.GetComponentInChildren<PauseMenuScript>());
			}
		}
	}
}
