using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController controller;

    public float movementSpeed = 14f;

    // gravity
    public float gravity = -10f;
    Vector3 velocity;

    // ground check
    public Transform groundCheck;
    public float checkRadius = 0.1f;
    public LayerMask ground;

    public bool isGrounded = false;

    // jump
    public float jump = 1f;

    // slope
    public bool isSliding = false;
    public float slopeLimit = 35f;
    private Vector3 slopeParallel;

    // Update is called once per frame
    void Update()
    {
        // is grounded calculations
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, ground);

        if (isGrounded) {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*movementSpeed*Time.deltaTime);

        // slopes, modified from https://answers.unity.com/questions/1502223/sliding-down-a-slope-with-a-character-controller.html
        if (isGrounded) {
            RaycastHit hit;
            Physics.Raycast(transform.position, Vector3.down, out hit);
            // Saving the normal
            Vector3 n = hit.normal;

            // Crossing my normal with the player's up vector (if your player rotates I guess you can just use Vector3.up to create a vector parallel to the ground
            Vector3 groundParallel = Vector3.Cross(transform.up, n);

            // Crossing the vector we made before with the initial normal gives us a vector that is parallel to the slope and always pointing down
            slopeParallel = Vector3.Cross(groundParallel, n);
            Debug.DrawRay(hit.point, slopeParallel * 10, Color.green);

            // Just the current angle we're standing on
            float currentSlope = Mathf.Round(Vector3.Angle(hit.normal, transform.up));

            // If the slope is on a slope too steep and the player is Grounded the player is pushed down the slope.
            if (currentSlope >= slopeLimit) {
                isSliding = true;
            }
            // If the player is standing on a slope that isn't too steep, is grounded, as is not sliding anymore we start a function to count time
            else if (currentSlope < slopeLimit && isSliding) {
                isSliding = false;
            }
        }

        if (isSliding) {
            controller.Move(slopeParallel.normalized / 2 * Time.deltaTime);
        }

        // jump
        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jump * -2f * gravity);
            if (isSliding) {
                // cut jump in halve
                velocity.y /= 2;
            }
        }

        velocity.y += gravity*Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}