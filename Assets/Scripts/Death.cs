using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public int health;
    public static bool dead;

    public AudioSource audioPlayer;
    public AudioClip sound;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        //Instance = this;
        audioPlayer.clip = sound;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -4)
        {
            dead = true;
            
        }
        if (dead == true)
        {
            if(audioPlayer.isPlaying == false)
            {
                audioPlayer.Play();
            }
            animator.SetBool("isDead", true);
            Kill();
        }
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(1);
       
        SceneManager.LoadScene("MainMenu");
    }

    
    public void Kill()
    {
        Debug.Log("DEAD");

        //ANIMATION
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.GetComponent<Rigidbody2D>().gravityScale = 18;
        gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 20);
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;

        //RETURN TO MENU
        StartCoroutine(Load());
        
    }
}
