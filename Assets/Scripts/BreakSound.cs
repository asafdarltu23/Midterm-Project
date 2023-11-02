using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakSound : MonoBehaviour
{
    public AudioClip Break;
    public AudioSource sound;
    public static BreakSound Instance;

    // Start is called before the first frame update
    void Start()
    {
        sound.clip = Break;
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SoundPlay(AudioSource source)
    {
        source.clip = Break;
        source.Play();
    }
}
