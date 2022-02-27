using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{

    public int pesos;
    public static GameManager inst;

    public Text scoreText;

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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
