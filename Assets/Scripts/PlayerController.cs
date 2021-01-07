using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    public float MovementPower;

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(transform.up * jumpPower);

        }
        else if (Input.GetKeyDown(KeyCode.E))
            {
                rb.AddForce(transform.right * MovementPower);

            }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddForce(transform.left * MovementPower);

        }

    }
}
