using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rigidbody;
    [SerializeField] private float speed = 10;

    [SerializeField] private float jumpForce;
    [SerializeField] private float groundDistance = 0.5f;

    [SerializeField] private float crouchYScale;
    [SerializeField] private float startYScale;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        startYScale = transform.localScale.y;
    }
    private void FixedUpdate() 
    {
        Movement();
        if (Input.GetKeyDown(KeyCode.Space)/* && IsGrounded()*/)
            Jump();

        if (Input.GetKeyDown(KeyCode.C))
            transform.localScale = new Vector3(transform.localScale.x, crouchYScale, transform.localScale.z);
        if (Input.GetKeyUp(KeyCode.C))
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);

    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, groundDistance);
    }

    private void Movement()
    {
        float z = Input.GetAxis("Vertical");     
        float x = Input.GetAxis("Horizontal");  
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
        //Debug.Log("VectorForward: " + forward + "\nVectorRight: " + right + "\nDirection: " + direction);
        rigidbody.AddForce(direction * speed, ForceMode.Acceleration);
    }

    void Jump()
    {
        
            Debug.Log("we are jumping");
            rigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        
    }

}
