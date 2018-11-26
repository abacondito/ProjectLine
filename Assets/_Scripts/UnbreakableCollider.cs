using UnityEngine;
using System.Collections;
public class UnbreakableCollider : MonoBehaviour
{
    public Transform DotPrefab;
    Vector3 lastDotPosition;
    bool lastPointExists;
    Plane objPlane;

    void Start()
    {
        lastPointExists = false;
        objPlane = new Plane(Camera.main.transform.forward * -1, this.transform.position);
    }
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            //Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            //Vector3 newDotPosition = mouseRay.origin - mouseRay.direction / mouseRay.direction.y * mouseRay.origin.y;
            Vector3 newDotPosition = new Vector3 (0.0f,0.0f,0.0f);
            Ray mRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            float rayDistance;
            if (objPlane.Raycast(mRay, out rayDistance))
                newDotPosition = mRay.GetPoint(rayDistance);

            if (newDotPosition != lastDotPosition)
            {
                MakeADot(newDotPosition);
            }
        }
    }
    void MakeADot(Vector3 newDotPosition)
    {
        Transform dot = (Transform)Instantiate(DotPrefab, newDotPosition, Quaternion.identity); //use random identity to make dots looks more different
        if (lastPointExists)
        {
            GameObject colliderKeeper = new GameObject("collider");
            BoxCollider2D bc = colliderKeeper.AddComponent<BoxCollider2D>();
            colliderKeeper.transform.position = Vector3.Lerp(newDotPosition, lastDotPosition, 0.5f);
            colliderKeeper.transform.LookAt(newDotPosition);
            bc.size = new Vector3(0.1f, 0.1f, Vector3.Distance(newDotPosition, lastDotPosition));
        }
        lastDotPosition = newDotPosition;
        lastPointExists = true;
    }
}