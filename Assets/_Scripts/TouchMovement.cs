using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Moved)
            {
                Vector3 newpos = Camera.main.ScreenToWorldPoint(touch.position);
                // Create a particle if hit
                this.transform.position = newpos;   
            }
        }
    }
}
