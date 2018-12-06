using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    private float timer = 10;

	// Use this for initialization
	void Start () {
        GameObject.Destroy(this.gameObject, timer);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
