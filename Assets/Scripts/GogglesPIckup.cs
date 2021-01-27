using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogglesPIckup : MonoBehaviour { 

private bool PickupAllowed;

    private SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupAllowed && Input.GetKeyDown(KeyCode.E))
        {

        }
            

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            PickupAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            PickupAllowed = false;
        }
    }
/*
    private void PickUp()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = cloutedpikachu;
    }
*/
}
