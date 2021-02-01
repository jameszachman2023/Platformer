using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpPower;

    public float MovementSpeed;

    public GameObject yellowPika;

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
        yellowPika = gameObject;
        startPos = transform.position;
        bc = gameObject.GetComponent<BoxCollider2D>();

    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
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
    private bool IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(bc.bounds.center, bc.bounds.size, 0f, Vector2.down, jumpDetectOffset, jumpableObjects);
        Color rayColor = Color.red;
        Debug.DrawRay(bc.bounds.center - new Vector3(bc.bounds.extents.x, bc.bounds.extents.y + jumpDetectOffset), Vector2.right * bc.bounds.size.x, rayColor);
        return raycastHit.collider != null;
    }
    
}
