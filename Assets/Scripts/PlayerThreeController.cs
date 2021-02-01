using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerThreeController : MonoBehaviour
{
    public float jumpPower;
    public float MovementSpeed;
    public float RotationSpeed;
    public GameObject pika;
    public float jumpDetectOffset;
    public LayerMask jumpableObjects;

    Rigidbody2D rb;

    SpriteRenderer sr;

    Vector3 startPos;

    BoxCollider2D bc;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        pika = gameObject;
        startPos = transform.position;
        bc = gameObject.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.C))
        {
            rb.AddForce(transform.up * jumpPower);

        }

        if (IsGrounded() && Input.GetKeyDown(KeyCode.Keypad8))
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
        private void OnCollisionEnter2D(Collision2D c)
        {
            if (c.gameObject.tag == "Platform")
            {

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
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, jumpDetectOffset, jumpableObjects);
        Color rayColor = Color.red;
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + jumpDetectOffset), Vector2.right * bc.bounds.size.x, rayColor);
        return raycastHit.collider != null;
    }


}
