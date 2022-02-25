using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRunnerScript : MonoBehaviour
{

    private Animator anim;
    public float speed = 10;
    public Rigidbody rb;

    float horizontalInput;

    public float jumpForce = 8f;
    public bool canJump;


    public CapsuleCollider CapsuleCol;

    void Start() {

        canJump = false;
        anim = GetComponent<Animator>();

        CapsuleCol = GetComponent<CapsuleCollider>();

        StartCoroutine(addVelocity());
    }

    void FixedUpdate() {

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        if (rb.position.y < -2f)
        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        }

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");


        if (canJump)
        {

            if (Input.GetKeyDown(KeyCode.Space))
            {

                anim.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            }
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {

                CapsuleCol.height = 1.078651f;
                CapsuleCol.center = new Vector3(0, 0.556852f, 0);
                anim.SetBool("Dash", true);
                Invoke("StopDash", 0.8f);
            }
            anim.SetBool("TocoSuelo", true);
        }
        else {

            fallingDown();
        }
    }
    public void StopDash() {

        CapsuleCol.height = 1.828487f;
        CapsuleCol.center = new Vector3(0, 0.880949f, 0.01583828f);
        anim.SetBool("Dash", false);
    }

    public void fallingDown() {

        anim.SetBool("TocoSuelo", false);
        anim.SetBool("Jump", false);
    }

    private void OnTriggerEnter(Collider col)
    {
        switch (col.gameObject.tag)
        {
            case "Spike":


                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                break;

        }

    }
    private IEnumerator addVelocity()
    {
        
            yield return new WaitForSeconds(5);
        //Vector3 forwardMove = transform.forward * (speed+5f) * Time.fixedDeltaTime;
        speed += 1f;
        StartCoroutine(addVelocity());
    }

}
