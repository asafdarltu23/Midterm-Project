using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int score = 0;
    public TextMeshProUGUI scoreDisplay;
    public static Score Instance;
    // Start is called before the first frame update
    void Start()
    {
        scoreDisplay.text = score.ToString();
        PlayerPrefs.SetString("Score", "0");
        Instance = this;
    }
    public void AddScore(int value)
    {
        score += value;
        scoreDisplay.text = score.ToString();
        PlayerPrefs.SetString("Score", score.ToString());
    }
}
