﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour {

    public float rotationSpeed = 45f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);

    }
}
