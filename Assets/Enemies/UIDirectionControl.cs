using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDirectionControl : MonoBehaviour {
	private Quaternion RelativeRotation;
	void Start () {
		RelativeRotation = transform.parent.localRotation;
	}
	
	void Update () {
		transform.rotation = RelativeRotation;
	}
}
