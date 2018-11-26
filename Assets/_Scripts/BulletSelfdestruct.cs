using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSelfdestruct : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}



    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Shield"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        GameObject go = collision.gameObject;
        if (go.CompareTag("Shield"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log("col exit");
        GameObject go = collision.gameObject;
        if (go.CompareTag("Shield"))
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}