using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed = 1f;
    public Sprite[] sprites;

    public SpriteRenderer renderer;
    public bool needsDuck = false;

    // Start is called before the first frame update
    void Start()
    {
        renderer.sprite = sprites[Random.Range(0, sprites.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = transform.position - transform.right * movepeed;
        transform.position -= transform.right * moveSpeed * Time.deltaTime;
    }
}
