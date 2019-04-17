using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTile : MonoBehaviour
{
    public int privAccess;
    public void OnTriggerEnter2D(Collider2D other)

    {
        if (other.CompareTag("Player") && other.GetComponent<PlayerAttributes>().priv == privAccess && other.GetComponent<PlayerAttributes>().health <10)
        {
            other.GetComponent<PlayerAttributes>().health += 1;
        }
        
    }


}
