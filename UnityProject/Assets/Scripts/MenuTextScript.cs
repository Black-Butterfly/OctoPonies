using UnityEngine;
using System.Collections;

public class MenuTextScript : MonoBehaviour {
	
	Color couleurEntrer = Color.green;
	Color couleurSortie = Color.white;
	int tailleEntrer = 58;
	int tailleSortie = 55;
	
	void OnMouseEnter()
	{
		guiText.material.color = couleurEntrer;
		guiText.fontSize = tailleEntrer;
	}
	
	void OnMouseExit()
	{
		guiText.material.color = couleurSortie;
		guiText.fontSize = tailleSortie;
	}
}
