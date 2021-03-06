﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BouncingBullet : MonoBehaviour {

    
    public float bulletSpeed;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb= gameObject.GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        rb.velocity = transform.right * -bulletSpeed;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            Spawnerangeli.Restart();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (other.transform.CompareTag("Enemy"))
        {   
            Destroy(other.gameObject);
            Destroy(gameObject);
            if(other.gameObject.GetComponents<AngeloAvvicinaColpisce>().Length != 0){
                Spawnerangeli.Aumenta();
            };

        }
    }
}