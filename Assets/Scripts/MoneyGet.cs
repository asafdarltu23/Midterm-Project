using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyGet : MonoBehaviour
{
    Collider col;
    public AudioSource player;
    public AudioClip sound;

    // Start is called before the first frame update
    void Start()
    {
        player.clip = sound;
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.Play();
            Score.Instance.AddScore(500);
            transform.parent.gameObject.SetActive(false);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
        }
    }
}
