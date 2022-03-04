using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public GameObject musicButton;

    public static bool audioOn = true;

    public AdsManager ads;

    public GameObject TrophiesPanel;
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
        ads.HideBanner();
        SceneManager.LoadScene("Level");

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

    public void Trophies() {

        TrophiesPanel.SetActive(true);

    }

    public void ReturnToTheMenu() {
        TrophiesPanel.SetActive(false);
    }
}
