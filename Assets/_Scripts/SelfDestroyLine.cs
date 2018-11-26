using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyLine : MonoBehaviour {
    LineRenderer line;
    public float timeLeft = 3.0f;
    float width;
    float decrease;


    // Use this for initialization
    void Start () {
        line = gameObject.GetComponent<LineRenderer>();
        width = line.startWidth;
        decrease = width / (timeLeft * 120);
    }
	
	// Update is called once per frame
	void Update () {
        timeLeft -= Time.deltaTime;
        
        line.startWidth -= decrease;
        line.endWidth -= decrease;
        if (timeLeft < 0)
        {
            if (gameObject != null)
                Object.Destroy(this.gameObject);          
        }
    }
}
