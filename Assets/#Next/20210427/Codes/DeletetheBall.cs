﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletetheBall : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y <= -3)
        {
            Destroy (this. gameObject);
        }
    }
}
