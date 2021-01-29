using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;
    public Rigidbody2D rb;
    public AudioSource jumpSource;
    public AudioSource bgmSource;
    public HUD hud;
    public Animator animator;

    private bool isGrounded = true;
    private bool hasDoubleJumped = false;

    private bool isDucking = false;

    private int score = 0;

    public void Restart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public int GetScore()
    {
        return score;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Obstacle obstacle = other.gameObject.GetComponent<Obstacle>();

        if(obstacle)
        {
            bool shouldLose = false;

            if(obstacle.needsDuck == false)
            {
                shouldLose = true;
            }
            else if(obstacle.needsDuck == true && isDucking == false)
            {
                shouldLose = true;
            }
            else
            {
                shouldLose = false;
            }

            if(shouldLose == false)
            {
                return;
            }

            bgmSource.Pause();
            hud.ShowRestartButton(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name != "Ground")
        {
            return;
        }

        isGrounded = true;
        hasDoubleJumped = false;
    }

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.Space) && (isGrounded == true || hasDoubleJumped == false))
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
            jumpSource.PlayOneShot(jumpSource.clip);

            if(isGrounded == false && hasDoubleJumped == false)
            {
                hasDoubleJumped = true;
            }
        }

        if (Input.GetKey(KeyCode.LeftShift) && isGrounded)

        {
            animator.SetBool("Ducking", true);
            isDucking = true;
        }
        else
        {
            animator.SetBool("Ducking", false);
            isDucking = false;
        }


            score++;

        isGrounded = false;
    }
}
