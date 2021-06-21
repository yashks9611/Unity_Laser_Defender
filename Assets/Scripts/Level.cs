﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
	[SerializeField] float delayInSeconds = 2f;

	// Start is called before the first frame update
	public void LoadStartMenu()
	{
		SceneManager.LoadScene(0);
	}

	public void LoadMainGame()
	{
		SceneManager.LoadScene("MainGame");
		GameSession gameSession = FindObjectOfType<GameSession>();
		if(!gameSession)
		{
			return;
		}
		gameSession.ResetGame();
	}

	public void LoadGameOver()
	{
		StartCoroutine(WaitAndLoad());
	}

	IEnumerator WaitAndLoad()
	{
		yield return new WaitForSeconds(delayInSeconds);
		SceneManager.LoadScene("GameOver");
	}

	public void QuitGame()
	{
		Application.Quit();  
	}
}
