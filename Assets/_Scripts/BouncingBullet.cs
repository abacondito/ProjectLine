using System.Collections;
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
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        } 
        else {
            CollisionWithWall(other);
        }
    }

    void CollisionWithWall(Collision2D other)
    {
        //For Reflecting The Bullet
        Vector3 reflectedPosition = Vector3.Reflect(transform.right, other.contacts[0].normal);
        rb.velocity = (reflectedPosition).normalized * bulletSpeed;

        //For Rotate The Bullet Towards its velocity
        Vector3 dir = rb.velocity;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        rb.MoveRotation(angle);
    }
}