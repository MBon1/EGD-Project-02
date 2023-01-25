using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTransision : MonoBehaviour
{
    [SerializeField] string destinationScene = "";

    private void OnCollisionEnter(Collision collision)
    {
        SceneController.LoadScene(destinationScene);
        Debug.Log(destinationScene);
    }
}
