using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogoMover : MonoBehaviour
{
    [SerializeField] private Sprite[]       logos;
    [SerializeField] private SpriteRenderer renderer1;
    [SerializeField] private Rigidbody2D    rb;
    [SerializeField] private GameObject     thisObj;

    [SerializeField] private Vector2        velocity;
    void Start()
    {
        int randomNum = Random.Range(0, logos.Length);
        renderer1.sprite = logos[randomNum];

        Destroy(thisObj, 7.5f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rb.position.y >= 2)
        {
            velocity.y = 0;
        }

        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
    }
}
