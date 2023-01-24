using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SamplePlayerController : MonoBehaviour
{
    //private PlayerInputActions playerInputActions;

    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    [SerializeField] float gravityScale = -3.0f;
    [SerializeField] float playerSpeed = 5.5f;
    [SerializeField] float playerRunningSpeed = 7f;
    private float movementSpeed = 0f;
    [SerializeField] float jumpHeight = 1.5f;
    bool releasedJump = false;

    private void Awake()
    {
        controller = this.GetComponent<CharacterController>();

        //playerInputActions = new PlayerInputActions();
        //playerInputActions.Player.Enable();

        movementSpeed = playerSpeed;
        //playerInputActions.Player.Jump.performed += Jump;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        groundedPlayer = controller.isGrounded;

        /*if (groundedPlayer)
        {
            movementSpeed = playerInputActions.Player.Run.IsPressed() ? playerRunningSpeed : playerSpeed;
        }*/

        // Get movement input
        //Vector2 inputVector = playerInputActions.Player.Movement.ReadValue<Vector2>();
        Vector2 inputVector = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(inputVector.x, 0, inputVector.y);

        // Clamp magnitude of input to 1 to prevent increased speed when moving diagonally w/o drifting
        move = Vector3.ClampMagnitude(move, 1f);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        //Jump();

        playerVelocity.y += Physics.gravity.y * Time.deltaTime;

        controller.Move((move * movementSpeed + playerVelocity) * Time.deltaTime);
    }

    /*void Jump()
    {
        groundedPlayer = controller.isGrounded;

        // If on the ground, stop vertical movement
        if (groundedPlayer)
        {
            playerVelocity.y = -0.5f;
            releasedJump = false;
        }

        // Changes the height position of the player.
        if (playerInputActions.Player.Jump.WasPerformedThisFrame() && groundedPlayer && !releasedJump)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * gravityScale * Physics.gravity.y);
        }

        if (playerInputActions.Player.Jump.WasReleasedThisFrame() && !groundedPlayer && !releasedJump *//*|| playerVelocity.y < 0*//*)
        {
            playerVelocity.y -= Mathf.Sqrt((gravityScale * Physics.gravity.y) / 2);
            releasedJump = true;
        }
    }*/
}
