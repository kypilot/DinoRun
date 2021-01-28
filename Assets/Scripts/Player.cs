using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;
    public Rigidbody2D rb;
    public AudioSource jumpSource;
    public HUD hud;

    private bool isGrounded = true;
    private bool hasDoubleJumped = false;

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
        if(other.gameObject.GetComponent<Obstacle>())
        {
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

        score++;

        isGrounded = false;
    }
}
