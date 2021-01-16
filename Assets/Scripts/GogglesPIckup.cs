using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GogglesPIckup : MonoBehaviour { 

private bool PickupAllowed;

    private SpriteRenderer rend;
    private Sprite cloutedpikachu, yellowPikaSprite;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        yellowPikaSprite = Resources.Load<Sprite>("33-339194_pokemon-pikachu-red-sprite");
        cloutedpikachu = Resources.Load<Sprite>("cloutedpikachu");
        rend.sprite = yellowPikaSprite;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PickupAllowed && Input.GetKeyDown(KeyCode.E))
        {
            //this.gameObject.GetComponent<SpriteRenderer>().sprite = cloutedpikachu;
            if (rend.sprite == yellowPikaSprite)
                rend.sprite = cloutedpikachu;
            else if(rend.sprite == cloutedpikachu)
                rend.sprite = yellowPikaSprite;

            //Destroy(gameObject);
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

    private void PickUp()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = cloutedpikachu;
    }
}
