using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShutsugenExplosionBall : MonoBehaviour
{
    public GameObject EXPLODESPHERE;
    public int SWITCH;
    public int NeedsSWITCH;


    void Start()
    {
        SWITCH = 0;
        NeedsSWITCH = 3;
    }

    private void OnTriggerEnter(Collider other)
    {
        //++SWITCH;
        Instantiate(EXPLODESPHERE);
        Destroy(gameObject);
    }

    void Update()
    {
        //if (NeedsSWITCH <= SWITCH)
        //{
            //Instantiate(EXPLODESPHERE);
        //}
    }
}
