using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LataScript : MonoBehaviour
{
   
    public float turnSpeed = 200f;
 
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


        Destroy(gameObject);
        
    
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
