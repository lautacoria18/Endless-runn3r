using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicScript : MonoBehaviour
{

    public AudioSource audioActual;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (!MainMenuScript.audioOn)
        {
            audioActual.mute = true;
        }
        else {


            audioActual.mute = false ;
        }
        
    }
}
