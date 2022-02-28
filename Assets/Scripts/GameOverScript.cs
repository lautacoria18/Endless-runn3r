using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOverScript : MonoBehaviour
{

    public static bool gameOver = false;
    public GameObject gameOverScreenUI;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            gameOverScreenUI.SetActive(true);
            Time.timeScale = 0f;
            

        }
    }


    public void Restart() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
