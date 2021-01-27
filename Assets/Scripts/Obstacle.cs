using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = transform.position - transform.right * movepeed;
        transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }
}
