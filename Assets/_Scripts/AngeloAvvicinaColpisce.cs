using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngeloAvvicinaColpisce : MonoBehaviour {

	public float speed = 2;
	public Transform Player;
	public GameObject proiettilePrefab;
	public float timeOrigin = 2.0f;
	public GameObject Arriva;
	public GameObject Fermo;
	public GameObject Carica;
	public GameObject Spara;
	private float timeleft;
	public float angolo;
    public Vector3 posizione;
    public Quaternion rotazione;

	// Use this for initialization
	void Start () {
		timeleft = timeOrigin;
        posizione = new Vector3(1, 1, 1);
        rotazione = Quaternion.identity;
	}

	// Update is called once per frame
	void Update () {
		Vector3 displacement = Player.position -transform.position;
		displacement = displacement.normalized;
		if (Vector2.Distance (Player.position, transform.position) > 4.0f) {
			transform.position += (displacement * speed * Time.deltaTime);

		} else {
			//do whatever the enemy has to do with the player

			if (Spara.activeSelf) {
				if (timeleft == timeOrigin) {
					angolo = Random.Range (-25.0f, 25.0f);
					posizione= transform.position;
                    rotazione = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0, 0, angolo));
                    Instantiate (proiettilePrefab, posizione,rotazione);
				}
				timeleft -= Time.deltaTime;
				if (timeleft < 0) {
					Spara.SetActive (false);
					Fermo.SetActive (true);
					timeleft = timeOrigin;
				}
	
			}

			if (Carica.activeSelf) {
				timeleft -= Time.deltaTime;
				if (timeleft < 0) {
					Carica.SetActive (false);
					Spara.SetActive (true);
					timeleft = timeOrigin;
				}
			}
			if (Fermo.activeSelf) {
				timeleft -= Time.deltaTime;
				if (timeleft < 0) {
					Fermo.SetActive (false);
					Carica.SetActive (true);
					timeleft = timeOrigin;
				}
			}
			if (Arriva.activeSelf) {
				Arriva.SetActive (false);
				Fermo.SetActive (true);
			}
		}



	}

}

