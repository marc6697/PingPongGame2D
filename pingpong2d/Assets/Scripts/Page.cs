using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Page : MonoBehaviour {
public bool isEscapetoExit;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
		{
			if(isEscapetoExit)
			{
				Application.Quit();
			}
			else
			{
				Back();
			}
		}
	}

	public void Mulai()
	{
		SceneManager.LoadScene("Main");
	}

	public void Back()
	{
		SceneManager.LoadScene("MainMenu");
	}


}
