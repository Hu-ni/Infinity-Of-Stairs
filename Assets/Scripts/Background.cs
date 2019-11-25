﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {
    public float bgspeed = 0.05f;
    Vector2 offset;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        offset = new Vector2(Time.time * bgspeed, 0);
        GetComponent<Renderer>().material.mainTextureOffset = offset;
    }
}
