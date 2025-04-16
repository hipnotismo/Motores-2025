using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    [SerializeField] private GameObject CamHolderFirstPerson;
    [SerializeField] private GameObject CamHolderThridPerson;

  
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)){
            CamHolderFirstPerson.SetActive(false);
            CamHolderThridPerson.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CamHolderFirstPerson.SetActive(true);
            CamHolderThridPerson.SetActive(false);
        }
    }
}
