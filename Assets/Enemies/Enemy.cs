using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : UnitHealth {
    AICharacterControl ai;
    [SerializeField] float aggroRange = 3f;
    private GameObject player;
    private Vector3 startPos;
    void Start() {
        ai = GetComponent<AICharacterControl>();
        player = GameObject.FindGameObjectWithTag("Player");
        startPos = transform.position;   
    }

    void Update() {
        var rangeFromPlayer = Vector3.Distance(this.transform.position, player.transform.position);
        if (rangeFromPlayer <= aggroRange) {
            ai.target = player.transform.position;
        } else {
            ai.target = startPos;   
        }
    }
}
