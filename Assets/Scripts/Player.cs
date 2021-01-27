using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float jumpPower = 5;
    public Rigidbody2D rb;

    private bool isGrounded = true;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.name != "Ground")
        {
            return;
        }

        isGrounded = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            rb.AddForce(new Vector2(0, jumpPower), ForceMode2D.Impulse);
        }

        isGrounded = false;
    }
}
