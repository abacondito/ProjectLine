using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    public float timer;

	// Use this for initialization
	void Start () {
        GameObject.Destroy(this.gameObject, timer);

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
