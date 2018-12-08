using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountainMover : MonoBehaviour {


    public float speed = 0.2f;
    public Transform teleportTransformEntrance;
    public Transform teleportTransformExit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        transform.position = new Vector3(transform.position.x + speed, transform.position.y, transform.position.z);
        if (transform.position.x >= teleportTransformEntrance.position.x) {
            transform.position = teleportTransformExit.position;
        }
		
	}
}
