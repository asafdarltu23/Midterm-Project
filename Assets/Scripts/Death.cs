using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Death : MonoBehaviour
{
    public int health;
    bool dead;
    public static Death Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        dead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.y < -6)
        {
            dead = true;
        }
        if (dead == true)
        {
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
        gameObject.GetComponent<Rigidbody2D>().freezeRotation = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent<PlayerMovement>().enabled = false;

        //RETURN TO MENU
        StartCoroutine(Load());

        //SOUND
    }
}
