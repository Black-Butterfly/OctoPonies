using UnityEngine;
using System.Collections;

public class MenuTextScript : MonoBehaviour {
	
	Color couleurEntrer = Color.green;
	Color couleurSortie = Color.black;
	int tailleEntrer;
	int tailleSortie;

	void Awake()
	{
		if(guiText.name == "Title")
		{
			guiText.fontSize = Screen.height/8;
		}
		else if(guiText.name == "Name" || guiText.name == "Key")
		{
			guiText.fontSize = Screen.height/18;
		}
		else
		{
			guiText.fontSize = Screen.height/10;
		}
		tailleEntrer = guiText.fontSize + 3;
		tailleSortie = guiText.fontSize;
	}

	public void Focus()
	{
		guiText.color = couleurEntrer;
		guiText.fontSize = tailleEntrer;
	}

	public void UnFocus()
	{
		guiText.color = couleurSortie;
		guiText.fontSize = tailleSortie;
	}
}
