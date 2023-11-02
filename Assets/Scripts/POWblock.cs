using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class POWblock : MonoBehaviour
{
    public AudioSource audioPlayer;
    public AudioClip sound;
    public static bool trig = false;

    public GameObject Camera;
    public float duration = 1;
    public bool start;
    

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer.clip = sound;
    }

    void Update()
    {
        if (start) 
        {
            start = false;
            StartCoroutine(Shake());
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trig = true;
            start = true;
            audioPlayer.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            trig = false;
            transform.parent.gameObject.SetActive(false);
        }
    }

    IEnumerator Shake()
    {
        Vector3 startPosition = Camera.gameObject.transform.position;
        float elapsedTime = 0;
        //Camera.gameObject.GetComponent<CemeraScript>().enabled = false;

        while (elapsedTime < duration)
        {
            startPosition = Camera.gameObject.transform.position;
            elapsedTime += Time.deltaTime;
            Camera.gameObject.transform.position = startPosition + Random.insideUnitSphere;
            yield return null;
        }

        //Camera.gameObject.GetComponent<CemeraScript>().enabled = true;
        Camera.gameObject.transform.position = startPosition;
        
    }
}
