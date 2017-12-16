using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public int playerPoints = 0;
    public int playerHealth = 5;

    public float speedMin = 0.2f;
    public float speedMax = 1.5f;

    private float speedCounter = 0;
    public static GameManager instance = null;

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
	
	// Update is called once per frame
	void Update () {

        if (playerHealth <= 0)
        {
            GameOver();
        }

        speedMin += speedCounter;
        speedMax += speedCounter;
        speedCounter += 0.0000001f;
    }

    private void GameOver()
    {
        Debug.Log("game over");
        SceneManager.LoadScene("PointScreen", LoadSceneMode.Single);
        playerHealth = 5;
        speedMin = 0.2f;
        speedMax = 1.5f;
    }
}
