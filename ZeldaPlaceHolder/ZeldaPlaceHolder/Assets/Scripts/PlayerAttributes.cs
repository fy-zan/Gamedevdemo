using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{

    public int health;
    public int money;
    public int priv;

    // Start is called before the first frame update
    void Start()
    {
        health = 5;
        money = 5;
        priv = 1;  
    }

}
