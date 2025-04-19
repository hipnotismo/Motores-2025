using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Vector3 _moveDirection;

    [SerializeField] private float horizontalAcceleration;
    [SerializeField] private float verticalForce;
    [SerializeField] private float maxSpeed;



    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() 
    {
        Movement();
        VerticalMovement();
    }


    private void Movement()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        _moveDirection = (transform.right * moveHorizontal + transform.forward * moveVertical).normalized;

        Vector3 horizontalVelocity = new Vector3(rigidbody.velocity.x, 0f, rigidbody.velocity.z);

        horizontalVelocity += _moveDirection * (horizontalAcceleration * Time.fixedDeltaTime);

        if (horizontalVelocity.magnitude >= maxSpeed)
        {
            horizontalVelocity = horizontalVelocity.normalized * maxSpeed;
        }

        rigidbody.velocity = new Vector3(horizontalVelocity.x, rigidbody.velocity.y, horizontalVelocity.z);
    }

    private void VerticalMovement()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddForce(Vector3.up * verticalForce, ForceMode.Impulse);
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            rigidbody.AddForce(Vector3.up * -verticalForce, ForceMode.Impulse);
        }

    }

}
