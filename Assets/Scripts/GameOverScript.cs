using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{
    public GameObject ControlsB;
    public static bool gameOver = false;
    public GameObject gameOverScreenUI;
    private bool alreadyDead;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1f;
        alreadyDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            ControlsB.SetActive(false);
            gameOverScreenUI.SetActive(true);
            Time.timeScale = 0f;
            if (!alreadyDead)
            {
                GameManager.deathCount++;
                alreadyDead = true;
            }
        }
    }


    public void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
