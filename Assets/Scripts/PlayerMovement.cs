using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float moveSpeed;

    public float turnSpeed;

    public float strafeSpeed;

    private Rigidbody2D bugRigidbody;

    public Vector2 moveDirection;

    public float difference;

    private void Start() {
        bugRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
        //Processing Inputs
        ProcessInputs();
        FaceMouse();
    }

    void FixedUpdate() {
        //Physics Calcs
        Move();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    // Check for Q/E pressing
    int CheckStrafe() {
        int x = 0;
        if (Input.GetKey(KeyCode.Q)) x -= 1;
        if (Input.GetKey(KeyCode.E)) x += 1;
        return x;
    }

    void Move() {
        // rb.AddForce(new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed));
        int s = CheckStrafe();
        if (s != 0) {
            bugRigidbody.AddForce(transform.right * strafeSpeed * s);
        } else {
            if (Input.GetAxisRaw("Vertical") != 0) {
                //bugRigidbody.AddForce(transform.up * moveSpeed * Input.GetAxisRaw("Vertical"));
                bugRigidbody.AddForce(Vector2.up * moveSpeed * Input.GetAxisRaw("Vertical"));
            }
            if (Input.GetAxisRaw("Horizontal") != 0) {
                //bugRigidbody.AddForce(transform.right * strafeSpeed * Input.GetAxisRaw("Horizontal"));
                bugRigidbody.AddForce(Vector2.right * moveSpeed * Input.GetAxisRaw("Horizontal"));
            }
        }

    }

    void FaceMouse() {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);
        difference = Vector2.SignedAngle(direction, transform.up);

        bugRigidbody.AddTorque(difference * -1 * turnSpeed);

    }
}
