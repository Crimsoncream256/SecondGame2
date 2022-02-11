using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaleemKarinAnim : MonoBehaviour
{
    private Animator anim = null;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1"))
        {
            anim.SetBool("bool",false);
        }
        else if (Input.GetKey("2"))
        {
            anim.SetBool("bool", true);
        }
        else
        {
            anim.SetBool("bool",false);
        }
    }
}
