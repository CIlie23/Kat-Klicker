﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class three_dee_spin : MonoBehaviour {
    public float rotationSpeed = 45f;
    // Use this for initialization
    void Start () {

}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
	}
}
