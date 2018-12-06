using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CostantSpeedForward : MonoBehaviour {

    private Rigidbody2D rb;
    private float velocity=2.0f;

    // Use this for initialization
    void Start () {
        rb=GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        rb.velocity = -velocity*(transform.right);
    }
}
