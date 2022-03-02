using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseScript : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    public GameObject pauseButton;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !GameOverScript.gameOver)
        {

            if (GameIsPaused)
            {

                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume() {

        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseButton.SetActive(true);
    }

    public void Pause() {

        if (!GameOverScript.gameOver) {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            GameIsPaused = true;
            pauseButton.SetActive(false);
        }

    }

    public void menu() {
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("MainMenu");

    }

    

}
