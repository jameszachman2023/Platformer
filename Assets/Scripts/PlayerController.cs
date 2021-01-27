using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;
    public float MovementSpeed;
    public GameObject yellowPika;

    Rigidbody2D rb;

    SpriteRenderer sr;

    Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        yellowPika = gameObject;
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.up * jumpPower);

        }
        /*
        if (Input.GetKeyDown(KeyCode.E))
            {
                rb.AddForce(transform.right * MovementSpeed);

            }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            rb.AddForce(-transform.right * MovementSpeed);

        }
        */
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector3(-MovementSpeed, 0, 0);
            sr.flipX = false;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector3(MovementSpeed, 0, 0);
            sr.flipX = true;
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector3(0, 0, 0);
            
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.velocity = new Vector3(0, 0, 0);
            
        }
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.RotateAround(yellowPika.transform.position);
        }
        */
        if (Input.GetKeyDown(KeyCode.F))
        {
            Destroy(yellowPika);
        }

        if (Input.GetKeyUp(KeyCode.F))
        {
            //Create(yellowPika);
        }
    }
    private void OnCollisionEnter2D (Collision2D c)
    {
        if (c.gameObject.tag == "Platform"){

            transform.SetParent(c.transform);
        }
        if (c.gameObject.tag == "Respawn")
        {
            transform.position = startPos;
            rb.velocity = Vector3.zero;
        }
    }
    private void OnCollisionExit2D(Collision2D c)
    {
        if (c.gameObject.tag == "Platform")
        {

            transform.SetParent(null);
        }
    }
    
}
