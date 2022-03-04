using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerRunnerScript : MonoBehaviour
{

    private Animator anim;
    public float speed = 10;
    public float speedVertical;
    public Rigidbody rb;

    float horizontalInput;

    public float jumpForce = 8f;
    public bool canJump;


    public int direction = 0;

    public CapsuleCollider CapsuleCol;


    public static float leftSide = -4.65f;
    public static float rightSide = 4.65f;


    public static int currentScore;




    void Awake() {

        Screen.SetResolution(720, 1280, true);
        Application.targetFrameRate = 60;
        

    }

    void Start() {

        canJump = false;
        anim = GetComponent<Animator>();

        CapsuleCol = GetComponent<CapsuleCollider>();

        StartCoroutine(addVelocity());

        ColorScript.currentColor= new Color(
      Random.Range(0f, 1f),
      Random.Range(0f, 1f),
      Random.Range(0f, 1f)

  );

        currentScore = 0;

        

    }

    void FixedUpdate() {

        Vector3 forwardMove = transform.forward * speedVertical * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * direction  * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + forwardMove);

        if (direction == 1)
        {
            if (this.gameObject.transform.position.x < 4.5f)
            {
                rb.MovePosition(rb.position + horizontalMove);
            }
        }
        else if (direction == -1) {
            if (this.gameObject.transform.position.x > -4.5f)
            {
                rb.MovePosition(rb.position + horizontalMove);
            }
        }

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

            if (Input.GetKeyDown(KeyCode.Space) ||  (MobileInput.swipeUp))
            {

                anim.SetBool("Jump", true);
                rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
                PlayerPrefs.SetInt("Jumps", PlayerPrefs.GetInt("Jumps") + 1);
                Debug.Log(PlayerPrefs.GetInt("Jumps"));
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) || MobileInput.swipeDown)
            {

                CapsuleCol.height = 1.078651f;
                CapsuleCol.center = new Vector3(0, 0.556852f, 0);
                anim.SetBool("Dash", true);
                Invoke("StopDash", 0.8f);
                PlayerPrefs.SetInt("Slides", PlayerPrefs.GetInt("Slides") + 1);
                Debug.Log(PlayerPrefs.GetInt("Slides"));
            }
            anim.SetBool("TocoSuelo", true);
        }
        else {

            fallingDown();
        }

        if (currentScore == 50)
        {
            PlayerPrefs.SetInt("Score50", 1);
        }
        if (currentScore == 100) { PlayerPrefs.SetInt("Score100", 1); }
        if (currentScore == 150) { PlayerPrefs.SetInt("Score150", 1); }
        if (currentScore == 200) { PlayerPrefs.SetInt("Score200", 1); }

    }

    public void JumpButton()
    {

        if (canJump)
        {
            anim.SetBool("Jump", true);
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            PlayerPrefs.SetInt("Jumps", PlayerPrefs.GetInt("Jumps") + 1);
        }
    }


    public void SlideButton() {

        if (canJump)
        {
            CapsuleCol.height = 1.078651f;
            CapsuleCol.center = new Vector3(0, 0.556852f, 0);
            anim.SetBool("Dash", true);
            Invoke("StopDash", 0.8f);
            PlayerPrefs.SetInt("Slides", PlayerPrefs.GetInt("Slides") + 1);
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

                GameOverScript.gameOver = true;             
                break;

            
        }
       
  

    }


    private IEnumerator addVelocity()
    {
        
            yield return new WaitForSeconds(5);

        speedVertical += 1f;
        StartCoroutine(addVelocity());

        ColorScript.currentColor = new Color(
      Random.Range(0f, 1f),
      Random.Range(0f, 1f),
      Random.Range(0f, 1f)

  );
    }



    public void right() {

        direction = 1;
        //transform.Translate(Vector3.right * Time.deltaTime * 20);
    }

    public void clickUp() {
        direction = 0;
    }

    public void left()
    {

        direction = -1;
 
    }

}
