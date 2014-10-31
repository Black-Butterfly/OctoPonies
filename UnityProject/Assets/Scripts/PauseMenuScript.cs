using UnityEngine;
using System.Collections;

public class PauseMenuScript : MonoBehaviour {

	public void thePauseMenu()
	{
		GUI.BeginGroup(new Rect(Screen.width / 2 - 150, 50, 300, 250));
		
		GUI.Box(new Rect(0, 0, 300, 250), "");
		
		GUI.Label(new Rect(15, 10, 300, 68), "PAUSE");
		
		if(GUI.Button(new Rect(55, 100, 180, 40), "Resume"))
			
		{
			Time.timeScale = 1.0f;
			AudioListener.pause = false;
			Destroy(this);
		}
		
		if(GUI.Button(new Rect(55, 150, 180, 40), "Restart"))
		{
			Application.LoadLevel("Lvl1");
			
		}

		if(GUI.Button(new Rect(55, 200, 180, 40), "Return Menu"))	
		{
			Application.LoadLevel("Menu");
		}
		
		GUI.EndGroup();
	}
	
	
	void OnGUI ()
		
	{
		//Screen.showCursor = true;
		thePauseMenu();	
	}
}
