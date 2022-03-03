using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject musicButton;

    public static bool audioOn = true;
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


        if (!audioOn) {

            musicButton.SetActive(false);
        }


    }



    public void Run() {
        SceneManager.LoadScene("SampleScene");

    }

    public void Music() {

        if (musicButton.activeInHierarchy) {
            audioOn = false;
            musicButton.SetActive(false);

        }
        else{
            audioOn = true;
            musicButton.SetActive(true);
        }

    }

    public void OpenInstagram()
    {
        Application.OpenURL("https://www.instagram.com/lauta.coria/");
    }
    public void OpenMailTo()
    {
        Application.OpenURL("mailto:lautarocori97@gmail.com?subject=Question");
    }
}
