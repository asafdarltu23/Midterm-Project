using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
      
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") && POWblock.trig == true)
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1000);
            other.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 200);
            other.gameObject.GetComponent<Rigidbody2D>().gravityScale = 8;
            other.gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
            other.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            other.gameObject.GetComponent<EnemyBehavior>().enabled = false;
        }
    }
}
