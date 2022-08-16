using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuStuff : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene(1);
    }

    public void AppQuit()
    {
        Application.Quit();
    }
}
