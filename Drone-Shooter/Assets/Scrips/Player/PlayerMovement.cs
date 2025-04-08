using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float speed = 10;

    // Movimiento WASD
    // Espacio Sube
    // Ctrl Baja

    // Mensaje de Unity 0 referencias
    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Mensaje de Unity 0 referencias
    private void FixedUpdate() // Interacciones con las Físicas
    {
        Movement();
    }

    private void Movement()
    {
        float z = Input.GetAxis("Vertical");     // -1 a 1 - SW
        float x = Input.GetAxis("Horizontal");   // -1 a 1 - AD
        float y = 0;

        if (Mathf.Abs(z) < 0.01f && Mathf.Abs(x) < 0.01f)
            return;

        Vector3 forward = transform.forward;
        Vector3 right = transform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 direction = (forward * z + right * x).normalized;
        Debug.Log("VectorForward: " + forward + "\nVectorRight: " + right + "\nDirection: " + direction);
        rigidbody.AddForce(direction * speed, ForceMode.Acceleration);
    }

}
