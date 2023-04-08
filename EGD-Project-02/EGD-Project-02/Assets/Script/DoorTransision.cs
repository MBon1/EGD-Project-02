using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransision : MonoBehaviour
{
    [SerializeField] string destinationScene = "";

    private void OnCollisionEnter(Collision collision)
    {
        TransitionScene();
    }

    public void TransitionScene()
    {
        SceneController.LoadScene(destinationScene);
        Debug.Log(destinationScene);
    }
}
