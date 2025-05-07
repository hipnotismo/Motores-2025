using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserAim : MonoBehaviour
{
    private LineRenderer lr;
    private bool laserState;
    private float range = 10;
    void Start()
    {
        lr = GetComponent<LineRenderer>();   
        laserState = true;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            lr.enabled = !lr.enabled;
        }

        RaycastHit hit;
        if(Physics.Raycast(transform.position,transform.forward, out hit, range))
        {
            if (hit.collider)
            {
                
                lr.SetPosition(0, transform.position);
                //lr.SetPosition(1, transform.position + (transform.forward * 3));
                lr.SetPosition(1,hit.point);

            }
        }
        else
        {
            
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position + (transform.forward * range));
        }
    }
}
