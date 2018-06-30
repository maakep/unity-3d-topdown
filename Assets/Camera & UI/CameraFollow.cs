using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[ExecuteInEditMode]
public class CameraFollow : MonoBehaviour {
	Transform Player;
	GameObject Cam;

	void Start () {
		if (Player == null) {
			Player = GameObject.FindGameObjectWithTag("Player").transform;
		}
		if (Cam == null) {
			Cam = Camera.main.gameObject;
		}
		
		Cam.transform.LookAt(Player);
	}
	
	void LateUpdate () {
		
		transform.position = Player.position;

		if (!Application.isPlaying) {
			Debug.Log("Editorscript updating camera rotation");
			Cam.transform.LookAt(Player);			
		}
	}
}
