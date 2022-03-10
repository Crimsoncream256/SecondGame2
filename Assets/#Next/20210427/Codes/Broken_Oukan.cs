using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broken_Oukan : MonoBehaviour
{
    public GameManager gm;

    void Start()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ball")
        {
            gm.PlusCoins(100);
            Destroy(gameObject);
        }
    }
}
