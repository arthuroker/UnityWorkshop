using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float speed = 1f;

    [SerializeField] float jumpForce = 1f;

    private float horizontalInput = 0f;
    private float forwardInput = 0f;  

    private Rigidbody rb;

    private bool isOnGround;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * Time.deltaTime * forwardInput * speed);
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * speed);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            Jump();
        }
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isOnGround = false;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isOnGround = true;
        }
    }


}
