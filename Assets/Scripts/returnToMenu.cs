using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class returnToMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReturnMenu(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
