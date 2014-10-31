using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public void UpdateScore(int Score)
	{
		guiText.text = "Score : " + Score.ToString();
	}
}
