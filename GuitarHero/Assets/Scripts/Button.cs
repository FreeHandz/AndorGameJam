using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour {

        public Button restartButton;

        void Start()
        {
        }

    public void restartLevel()
    {
        SceneManager.LoadScene("Game", LoadSceneMode.Single);
    }

}
