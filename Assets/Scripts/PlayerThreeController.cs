using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeController : MonoBehaviour
{
    public float jumpPower;
    public float MovementSpeed;
    public float RotationSpeed;
    public GameObject pika;

    Rigidbody2D rb;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        pika = gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            rb.AddForce(transform.up * jumpPower);

        }

        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            rb.AddForce(transform.up * jumpPower);

        }
        
        if (Input.GetKey(KeyCode.Keypad9))
        {
            transform.RotateAround(pika.transform.position, Vector3.forward, -Time.deltaTime * 200);

        }

        if (Input.GetKey(KeyCode.Keypad7))
        {
            transform.RotateAround(pika.transform.position, Vector3.forward, Time.deltaTime * 200);

        }

        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            rb.velocity = new Vector3(-MovementSpeed, 0, 0);
            sr.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            rb.velocity = new Vector3(MovementSpeed, 0, 0);
            sr.flipX = true;
        }

        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            rb.velocity = new Vector3(0, 0, 0);
            
        }

        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            rb.velocity = new Vector3(0, 0, 0);
            
        }

    }
}
