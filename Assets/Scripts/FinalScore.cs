using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{
    public TextMeshProUGUI scoreDisplay;
    

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = "0000";
        scoreDisplay.text = PlayerPrefs.GetString("Score");
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}
