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
                lr.SetPosition(1, new Vector3(0,0,-hit.distance));
            }
        }
        else
        {
            lr.SetPosition(0, new Vector3(0,0,100));
        }
    }
}
