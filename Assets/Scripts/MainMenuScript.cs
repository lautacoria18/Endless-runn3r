using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject musicButton;
    // Start is called before the first frame update

    void Awake() {

        Screen.SetResolution(720, 1280, true);
        Application.targetFrameRate = 60;
    }
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void Run() {
        SceneManager.LoadScene("SampleScene");

    }

    public void Music() {

        if (musicButton.activeInHierarchy) {

            musicButton.SetActive(false);

        }
        else{

            musicButton.SetActive(true);
        }

    }
}
