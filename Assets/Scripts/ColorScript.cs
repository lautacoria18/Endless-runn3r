using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorScript : MonoBehaviour
{

    private ParticleSystem ps;
    public static Color currentColor;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        var main = ps.main;

        // float randomNumber = Random.Range(0f, 32f);
        // Color newColor = new Color(randomNumber, randomNumber, randomNumber);
        /*
                main.startColor = new Color(
              Random.Range(0f, 1f),
              Random.Range(0f, 1f),
              Random.Range(0f, 1f)

          );
          */

        //main.startColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);

        main.startColor = currentColor;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
