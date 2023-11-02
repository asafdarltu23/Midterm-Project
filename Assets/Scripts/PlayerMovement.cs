using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator animator;

    public AudioSource audioPlayer;
    public AudioClip sound;

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

    bool facingRight = true;
    void Start()
    {
        body = this.gameObject.GetComponent<Rigidbody2D>();
        audioPlayer.clip = sound;
    }

    // Update is called once per frame
    void Update()
    {
        if (physicsMovement)
        {
            PhysicsMovement();
            if (!Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance) && Death.dead == false)
            {
                animator.SetBool("isJumping", true);
            }

            if (Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance) || Death.dead == true)
            {
                animator.SetBool("isJumping", false);
            }
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
        

        Debug.DrawRay(this.transform.position + raycastOriginOffset,
            -Vector2.up * minFloorDistance, Color.red);

        bool middleRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset,
            -Vector2.up * minFloorDistance);
        bool leftRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset - Vector3.right * distanceBetweenRays,
            -Vector2.up * minFloorDistance);
        bool rightRay = Physics2D.Raycast(this.transform.position + raycastOriginOffset + Vector3.right * distanceBetweenRays,
            -Vector2.up * minFloorDistance);

        float xMov = Input.GetAxis("Horizontal");
        //if (raw)
        //{
          //  xMov = Input.GetAxis("Raw");
        //}
        //else
        //{
          //  xMov = Input.GetAxis("Horizontal");
        //}
        
        body.velocity = new Vector2(xMov * speed, body.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            if (Physics2D.Raycast(this.transform.position + raycastOriginOffset, -Vector2.up, minFloorDistance))
            {
                audioPlayer.Play();
                body.AddForce(Vector2.up * jumpForce * 10);
            }
        }
        

            if (xMov > 0 && facingRight == false)
        {
            facingRight = !facingRight;
            Vector2 localscale = gameObject.transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }
        else if (xMov < 0 && facingRight == true)
        {
            facingRight = !facingRight;
            Vector2 localscale = gameObject.transform.localScale;
            localscale.x *= -1;
            transform.localScale = localscale;
        }

        animator.SetFloat("Speed", Mathf.Abs(xMov * speed));
    }
}
