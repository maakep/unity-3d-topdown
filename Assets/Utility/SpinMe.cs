﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpinMe : MonoBehaviour {

	[SerializeField] float xRotationsPerMinute = 1f;
	[SerializeField] float yRotationsPerMinute = 1f;
	[SerializeField] float zRotationsPerMinute = 1f;
	float minuteTimesDegrees = 60*360;
	void Update () {			

        float xDegreesPerFrame = Time.deltaTime / 60 * 360 * xRotationsPerMinute;
        transform.RotateAround (transform.position, transform.right, xDegreesPerFrame);

		float yDegreesPerFrame = Time.deltaTime /  60 * 360 * yRotationsPerMinute;
        transform.RotateAround (transform.position, transform.up, yDegreesPerFrame);

        float zDegreesPerFrame = Time.deltaTime /  60 * 360 * zRotationsPerMinute;
        transform.RotateAround (transform.position, transform.forward, zDegreesPerFrame);
	}
}
