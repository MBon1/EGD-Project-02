using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Implementation from https://www.youtube.com/watch?v=PHa5SNe1Mmk
public class BGMAudioManager : MonoBehaviour
{
    private static BGMAudioManager instance;
    private static AudioClip clip;

    private void Awake()
    {
        if (instance == null || (instance != this && this.GetComponent<AudioSource>().clip != clip))
        {
            if (instance != null)
            {
                DestroyInstance();
                Destroy(instance.gameObject);
            }
            instance = this;
            clip = this.GetComponent<AudioSource>().clip;
            DontDestroyOnLoad(transform.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public static void DestroyInstance()
    {
        if (instance != null)
            SceneManager.MoveGameObjectToScene(instance.gameObject, SceneManager.GetActiveScene());
    }
}
