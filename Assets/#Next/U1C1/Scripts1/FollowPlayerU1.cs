﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerU1 : MonoBehaviour
{
    public GameObject player;
    public Vector3 offset = new Vector3(0, 5, -7);
    void Start()
    {
        
    }

    void Update()
    {
        transform.position = player.transform.position + offset;
    }
}
