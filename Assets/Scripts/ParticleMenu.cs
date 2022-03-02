using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMenu : MonoBehaviour
{

    private ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var main = ps.main;
        main.startColor = new Color(
              Random.Range(0f, 1f),
              Random.Range(0f, 1f),
              Random.Range(0f, 1f)

          );
    }
}
