using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    private int pesos;
    public static GameManager inst;
    private int maxScore;

    public Text scoreText;
    public Text maxScoreText;

    public AdsManager ads;
    public static int deathCount = 0;

    public void IncrementScore() {

        pesos++;
        scoreText.text = pesos.ToString();
        

    }

    private void Awake() {

        inst = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        maxScore = PlayerPrefs.GetInt("maxScore");
        maxScoreText.text = maxScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (pesos >= maxScore) {

            maxScore = pesos;
            PlayerPrefs.SetInt("maxScore", maxScore);
            maxScoreText.text = PlayerPrefs.GetInt("maxScore").ToString();
        }
        if (deathCount > 4) {

            ads.PlayAd();
            deathCount = 0;
        }
   
    }
}
