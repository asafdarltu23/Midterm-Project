using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBreak : MonoBehaviour
    
{
    Collider col;
    public Transform particle;
    public AudioSource source;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BreakSound.Instance.SoundPlay(source);
            Instantiate(particle, this.transform.position, this.transform.rotation);

            transform.parent.gameObject.SetActive(false);
            this.gameObject.GetComponent<Collider2D>().enabled = false;
            transform.parent.gameObject.GetComponent<Collider2D>().enabled = false;

            
        }
    }
}
