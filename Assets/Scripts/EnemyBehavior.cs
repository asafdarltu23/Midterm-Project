using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    public float speed;
    float xMovDirect = -1;
    public Rigidbody2D rb;

    public float minObsticleDistance;
    public Collider2D col;
    public Collider2D NoFall;

    public static EnemyBehavior Instance;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody2D>();
        col = this.gameObject.GetComponentInChildren<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, new Vector2(xMovDirect, -0.5f));
        RaycastHit2D floorBelow = Physics2D.Raycast(this.transform.position + new Vector3(5,0,-0.5f), Vector2.down);
        rb.velocity = new Vector2(xMovDirect * speed, rb.velocity.y);

        if (hit.distance < minObsticleDistance &&
            hit.collider.tag != "Player")
        {
            Flip();
        }

        if (gameObject.transform.position.y <= -50)
        {
            Score.Instance.AddScore(200);
            Destroy(this.gameObject);
        }
    }

    void Flip()
    {
        xMovDirect = xMovDirect * -1;

        Vector2 localScale = gameObject.transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Flip();
            rb.AddForce(Vector2.up * 50);
        }

        if (other.gameObject.name == "NoFall")
        {
            Flip();
        }

        if (other.CompareTag("Player"))
        {
            Death.dead = true;
        }
    }
}
