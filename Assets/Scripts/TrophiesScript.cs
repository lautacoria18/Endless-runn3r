using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophiesScript : MonoBehaviour
{

    public GameObject t50, t100, t150, t200, tJump, tSlide;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Slides") >= 500) { tSlide.SetActive(true); }
        if (PlayerPrefs.GetInt("Jumps") >= 500) { tJump.SetActive(true); }
        if (PlayerPrefs.GetInt("Score50") == 1) { t50.SetActive(true); }
        if (PlayerPrefs.GetInt("Score100") == 1) { t100.SetActive(true); }
        if (PlayerPrefs.GetInt("Score150") == 1) { t150.SetActive(true); }
        if (PlayerPrefs.GetInt("Score200") == 1) { t200.SetActive(true); }
    }
}
