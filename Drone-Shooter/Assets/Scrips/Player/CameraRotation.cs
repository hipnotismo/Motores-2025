using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [Header("Setup")]

    [SerializeField] private Transform PlayerBody;

    [SerializeField] private Transform CamHolder;

    [Header("Movement")]

    [SerializeField] private float MouseSensitivity = 100f;

    private float XRotation;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Update()
    {
        var mouseX = Input.GetAxisRaw("Mouse X") * MouseSensitivity * Time.deltaTime;
        var mouseY = Input.GetAxisRaw("Mouse Y") * MouseSensitivity * Time.deltaTime;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -70f, 70f);

        CamHolder.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
