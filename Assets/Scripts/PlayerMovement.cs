using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D body;
    public float jumpForce;
    public float speed;

    public float minFloorDistance;
    public Vector3 raycastOriginOffset;
    public float distanceBetweenRays;

    [SerializeField]
    private bool physicsMovement = true;
    [SerializeField]
    bool raw;
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (physicsMovement)
        {
            PhysicsMovement();
        }
        else
        {
            KinemeticMovement();
        }
    }

    void KinemeticMovement()
    {

    }

    void PhysicsMovement()
    {
        bool middleRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset,
            -Vector2.up * minFloorDistance);
        bool leftRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset - Vector3.right * distanceBetweenRays,
            -Vector2.up * minFloorDistance);
        bool rightRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset + Vector3.right * distanceBetweenRays,
            -Vector2.up * minFloorDistance);

        if (Input.GetButtonDown("Jump")
            && Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance))
        {
            body.AddForce(Vector2.up * jumpForce);
        }

        float xMov;
        if (raw)
        {
            xMov = Input.GetAxis("Raw");
        }
        else
        {
            xMov = Input.GetAxis("Horizontal");
        }

        body.velocity = new Vector2(xMov * speed, body.velocity.y);
    }
}
