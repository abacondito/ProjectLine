using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomBullets : MonoBehaviour {

    public float cooldown;
    private float timer;
    public int bulletNumber;
    private Vector3[] posVector;
    public Transform playerPos;
    public GameObject bulletPrefab;
    private Transform spawnTransf;
    private GameObject bulletInstance;

    void Awake()
    {

    }

    // Use this for initialization
    void Start () {
        posVector = new Vector3[bulletNumber];
        spawnTransf = transform;
        timer = 0.0f;

    }
	
	// Update is called once per frame
	void Update () {
        if (timer>=cooldown) {
                    
            for (int i = 0; i < bulletNumber; i++) {                
                posVector[i] = new Vector3(RandomRange(), Random.Range(0.0F, 12.0F), 0.0f);
            }

            foreach (Vector3 pos in posVector) {
                spawnTransf.position = playerPos.position + pos;
                spawnTransf.LookAt(playerPos);//Aggiungere aimbot
                spawnTransf.Rotate(0.0f,90.0f,0.0f);
                bulletInstance = Instantiate(bulletPrefab, spawnTransf.position,spawnTransf.rotation);
            }
            timer = 0.0f;
        }
	}

    private void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
    }

    private float RandomRange()
    {
        var rand = Random.Range(8.0f, 12.0f);
        if (Random.Range(0, 100) <= 50)
        {
            rand = rand * -1f;
        }
        return rand;
    }
}
