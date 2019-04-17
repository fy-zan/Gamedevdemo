using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransportTile : MonoBehaviour
{
    public GameObject TileToTransport;
    private bool playerInRange;

    public int privAccess;



    // Update is called once per frame
    void Update()
    {
       

        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            GameObject player = GameObject.FindWithTag("Player");
            if (player.GetComponent<PlayerAttributes>().priv == privAccess)
            { player.transform.position = TileToTransport.transform.position; }
               
        }

    }






    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") )
        { 
                playerInRange = true;
        }

    }


    public void OnTriggerExit2D(Collider2D other)

    {
        
        if (other.CompareTag("Player"))
            { playerInRange = false; }
    }



}
