using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    
    GameObject player1;
    GameObject player2;
    GameObject player3;
    int pCount;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GameObject.Find("Player");
        player2 = GameObject.Find("PinkPika");
        player3 = GameObject.Find("GreenPika");
        pCount = -1;


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            pCount = (pCount + 1)%3;

            /*
            if (pCount == 0){
                transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -10);

            }
            else if (pCount == 1){
                    transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y, -10);
                    
            }
            else if (pCount == 2){
                    transform.position = new Vector3(player3.transform.position.x, player3.transform.position.y, -10);
                    
            }
            */
            
        }

        if (pCount == 0)
        {
            transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y, -10);

        }
        else if (pCount == 1)
        {
            transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y, -10);

        }
        else if (pCount == 2)
        {
            transform.position = new Vector3(player3.transform.position.x, player3.transform.position.y, -10);

        }

    }

}
