using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log($"Collision {collision.gameObject.name}!");
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log($"Trigger {other.gameObject.name}!");
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        // Local <-> World <-> Viewport <-> Screen

        //스크린 좌표 추출
        //Debug.Log($"Clicked {Input.mousePosition}!");

        Debug.Log(Camera.main.ScreenToViewportPoint(Input.mousePosition));



        /*
        RaycastHit hit;
        Vector3 look = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position + Vector3.up, look * 10, Color.red);

        if (Physics.Raycast(transform.position + Vector3.up, look,out hit, 10))
        {
            Debug.Log("RayCast!");
        }
        */
    }
}
