using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataScript : MonoBehaviour
{
   
    public float turnSpeed = 200f;

    public int currentScore = 0;

    void Start()
    {
        
    }

    void OnTriggerEnter(Collider obj) {

        if (obj.gameObject.tag == "Spike")
        {

            Destroy(gameObject);
            return;
        }

        if (obj.gameObject.name != "Player")
        {
            
            return;
        }
        if (obj.gameObject.name != "Can")
        {

            Destroy(gameObject);
        }

        GameManager.inst.IncrementScore();
        PlayerPrefs.SetInt("ScoreTotal", PlayerPrefs.GetInt("ScoreTotal") + 1);
        PlayerRunnerScript.currentScore++;

        Destroy(gameObject);
        
    
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);




       // Debug.Log(currentScore);
    }
}
