using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameObject win;
    public GameObject lose;

    public GameObject robot;

    void Awake()
    {
        win.SetActive(false);
        lose.SetActive(false);
    }

	void Update () {
	    if(Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
	}

    public void Win()
    {
        win.SetActive(true);
        robot.GetComponent<Movement>().Win();
    }

    public void Lose()
    {
        lose.SetActive(true);
        robot.GetComponent<Movement>().Lose();
    }
}
