using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	void Awake()
	{
		guiText.fontSize = Screen.height / 8;
	}

	public void UpdateScore(int Score)
	{
		guiText.text = "Score : " + Score.ToString();
	}
}
