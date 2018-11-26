using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Solidify : MonoBehaviour {

    private TrailRenderer trail;
    private EdgeCollider2D edgeCollider;
    private Rigidbody2D rigid2D;

    // Use this for initialization
    void Awake () {
        trail = GetComponent<TrailRenderer>();
        rigid2D= gameObject.AddComponent<Rigidbody2D>() as Rigidbody2D;
        rigid2D.useAutoMass = true;
        rigid2D.isKinematic = true;
        edgeCollider = gameObject.AddComponent<EdgeCollider2D>() as EdgeCollider2D;


    }
	
	// Update is called once per frame
	void Update () {
        Vector3[] vertexList = new Vector3[trail.positionCount];
        trail.GetPositions(vertexList);
        edgeCollider.points =  ConvertArray(vertexList);
        

	}

    Vector2[] ConvertArray(Vector3[] v3)
    {
        Vector2[] v2 = new Vector2[v3.Length];
        for (int i = 0; i < v3.Length; i++)
        {
            Vector3 tempV3 = v3[i];
            v2[i] = new Vector2(tempV3.x - 5.11f, tempV3.y - 2.33f);
        }
        return v2;
    }
}
