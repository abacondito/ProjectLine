using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisioneAreaNemici : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {

        if (other.transform.CompareTag("Enemy")){ 
			if(other.gameObject.GetComponents<AngeloAvvicinaColpisce>().Length != 0){
            	other.GetComponent<AngeloAvvicinaColpisce>().ferma();
			}
        };
    }




}
