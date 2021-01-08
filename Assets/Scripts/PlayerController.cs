using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    public float MovementSpeed;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.up * jumpPower);

        }
        if (Input.GetKeyDown(KeyCode.E))
            {
                rb.AddForce(transform.right * MovementSpeed);

            }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddForce(-transform.right * MovementSpeed);

        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector3(-MovementSpeed, 0, 0);

        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector3(MovementSpeed, 0, 0);

        }

    }
}
