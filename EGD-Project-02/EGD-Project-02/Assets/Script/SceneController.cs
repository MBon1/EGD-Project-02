using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Transition Scene
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public static void LoadTutorial()
    {
        LoadScene("Tutorial");
    }
    public static void LoadTitle()
    {
        LoadScene("Menu");
    }
}
