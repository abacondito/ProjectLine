using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchKill : MonoBehaviour {

    public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetMouseButtonDown(0))//if (Input.touchCount > 0)
        {
            Destroy(player);
        }
	}
}
