using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    public float velocidadMovimiento = 5.0f;
    public float velocidadRotatacion = 200.0f;
    private Animator anim;
    public float x, y;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        transform.Rotate(0, x * Time.deltaTime * velocidadRotatacion, 0);
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);


        anim.SetFloat("VelX", x);
        anim.SetFloat("VelY", y);

        if (Input.GetKey(KeyCode.F)) {
            //rb.velocity = new Vector3(0, 10, 0);
            anim.SetBool("Dash", true);
            Invoke("StopDashing", 1f);
            //StartCoroutine(DashCoroutine());

        }

        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Jump", true);
            //rb.velocity = new Vector3(0, 2, 0);
            Invoke("StopJumping", 1f);
        }


    }

    private void StopJumping()
    {

        anim.SetBool("Jump", false);
    }

    private void StopDashing() {

        anim.SetBool("Dash", false);
    }
    private IEnumerator DashCoroutine()
    {
        float startTime = Time.time; // need to remember this to know how long to dash
        while (Time.time < startTime + 1.0f)
        {
            transform.Translate(0, 0, 0.5f * Time.deltaTime * velocidadMovimiento);
            //transform.Translate(transform.forward * 20.0f * Time.deltaTime);
            // or controller.Move(...), dunno about that script
            yield return null; // this will make Unity stop here and continue next frame
        }
    }

}
