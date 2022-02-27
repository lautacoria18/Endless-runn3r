using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundLogic : MonoBehaviour
{

    public PlayerRunnerScript player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerStay(Collider col) {
        if (col.gameObject.tag == "Can") {
            
            player.canJump = false;
            
        }
        else
        {
            player.canJump = true;
        }
    }

    private void OnTriggerExit(Collider other) {


        player.canJump = false;
    }
}
