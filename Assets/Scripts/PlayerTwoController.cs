using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwoController : MonoBehaviour
{
    public float jumpPower;
    public float MovementSpeed;

    Rigidbody2D rb;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            rb.AddForce(transform.up * jumpPower);

        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            rb.AddForce(transform.right * MovementSpeed);

        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            rb.AddForce(-transform.right * MovementSpeed);

        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            rb.velocity = new Vector3(-MovementSpeed, 0, 0);
            sr.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            rb.velocity = new Vector3(MovementSpeed, 0, 0);
            sr.flipX = true;
        }

    }
}

