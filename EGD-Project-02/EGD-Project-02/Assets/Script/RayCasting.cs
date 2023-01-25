using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasting : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] PlayerController playerController;
    [SerializeField] RayCastingUI rayCastUI;
    //[SerializeField] 

    // Start is called before the first frame update
    void Start()
    {
        camera.orthographic = false;
        playerController.canMove = true;
        rayCastUI.EnableRayCastUI(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift) ||
            (Input.GetKeyDown(KeyCode.Escape) && camera.orthographic))
        {
            ChangePerspective();
        }
    }

    void ChangePerspective()
    {
        camera.orthographic = !camera.orthographic;
        playerController.canMove = !playerController.canMove;
        rayCastUI.EnableRayCastUI(camera.orthographic);
    }
}
