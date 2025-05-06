using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAim : MonoBehaviour
{
    private LineRenderer lr;

    void Start()
    {
        lr = GetComponent<LineRenderer>();   
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit))
        {
            if (hit.collider)
            {
                //lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 50));
                //lr.SetPosition(1, new Vector3(transform.position.x,transform.position.y,hit.distance));
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, transform.position + (transform.forward * 3));
            }
        }
        else
        {
            //lr.SetPosition(0, new Vector3(transform.position.x, transform.position.y, 50));
            //lr.SetPosition(1, new Vector3(transform.position.x, transform.position.y, hit.distance));
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + (transform.forward * 3));
        }
    }
}
