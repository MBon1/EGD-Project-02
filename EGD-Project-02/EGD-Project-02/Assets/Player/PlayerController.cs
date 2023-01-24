using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    CharacterController characterController;    // Character Controller

    Vector3 hitNormal;

    Vector3 movementDirection = Vector3.zero;   // Direction the player is moving
    [SerializeField] float speed = 5.5f;        // Player movement speed
    [SerializeField] float jumpSpeed = 4;       // Player jumping speed
    [SerializeField] float gravitySpeed = 10;   // Speed of Gravity
    float maxSlope;
    bool onStableGround;

    SceneController sceneManager;

    /*[SerializeField] GameObject bullet;
    [SerializeField] GameObject[] bullets = new GameObject[3];
    [SerializeField] int bulletCap = 3;
    int bulletStock = 0;*/

    /*Light light;
    float lightIntensity = 0;*/

    private void Awake()
    {
        characterController = GetComponent<CharacterController>();
        sceneManager = GetComponent<SceneController>();

        /*light = GetComponentInChildren<Light>();
        lightIntensity = light.intensity;
        light.intensity = 0;*/
    }

    // Start is called before the first frame update
    void Start()
    {
        maxSlope = characterController.slopeLimit;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded.  If so, allow for the player to input movement controls.
        if (characterController.isGrounded)
        {
            float horizontalInput = Input.GetAxisRaw("Horizontal");
            float verticalInput = Input.GetAxisRaw("Vertical");

            movementDirection = new Vector3(horizontalInput, 0, verticalInput);
            movementDirection = transform.TransformDirection(movementDirection);
            movementDirection *= speed;

            // If the player jumps, apply jump speed to player's movement
            if (Input.GetButton("Jump"))
            {
                movementDirection.y = jumpSpeed;
            }

            // If the player is on a surface where the slope exceeds the maximum slope, 
            // push the player back to cause them to slide off
            if (!onStableGround)
            {
                float slopeAngle = 1f - hitNormal.y;
                float pushBackSpeed = (gravitySpeed / 3 * 2 * slopeAngle);
                movementDirection.x += slopeAngle * hitNormal.x * pushBackSpeed;
                movementDirection.z += slopeAngle * hitNormal.z * pushBackSpeed;
            }
        }

        // Check if the player's colliding with a surface that causes the player to be on a slope
        // greater than the player's maximum slope
        if(Vector3.Angle(Vector3.up, hitNormal) > maxSlope)
        {
            onStableGround = false;
        }
        else
        {
            onStableGround = characterController.isGrounded;
        }

        // Apply Gravity
        movementDirection.y -= gravitySpeed * Time.deltaTime;
        // Move the player
        characterController.Move(movementDirection * speed * Time.deltaTime);

        // Fire Projectile if the player has projectiles in stock
        /*if (bulletStock > 0 && Input.GetButtonDown("Fire1"))
        {
            fireBullet();
        }*/
    }

    /* Player Collision */
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Record the normal of what the player hit
        hitNormal = hit.normal;

        // Check if the player hit something
        if (hit != null)
        {
            string hitTag = hit.gameObject.tag;

            /*// If the player hit a projectile spawner, restock the player's projectiles
            if (hitTag == "ProjectileSpawner")
            {
                hit.gameObject.GetComponent<ProjectileSpawner>().CollectProjectile();
                bulletStock = bulletCap;
            }

            // If the player hit a Collectable, collect the Collectable
            if (hitTag == "Collectable")
            {
                hit.gameObject.GetComponent<Collectable>().Collect();
            }

            // If the player hit the flashlight, turn on the player's light
            if (hitTag == "Flashlight")
            {
                hit.gameObject.GetComponent<Collectable>().Collect();
                light.intensity = lightIntensity;
            }

            // If the player hit UFO and the player has collected all of the parts, send the player to the win screen
            if (hitTag == "UFO" && hit.gameObject.GetComponent<UFO>().GetPartCount() == 0)
            {
                Cursor.lockState = CursorLockMode.None;
                sceneManager.LoadScene("Win");
            }*/
        }
    }

    /* Fires a projectile if possible
     * Modifies: Instantiates a new projectile
    */
    private void fireBullet()
    {
        /*// Check if the player has enough projectiles in stock to throw a new one
        if(bulletStock > 0)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                // If this element in bullets is null, then instantiate the projectile
                if (bullets[i] == null)
                {
                    // Instantiate projectile
                    Vector3 projectilePosition = transform.position + transform.forward + transform.up;
                    GameObject projectile = Instantiate(bullet, projectilePosition, transform.rotation);
                    Projectile bulletComponent = projectile.GetComponent<Projectile>();

                    bullets[i] = projectile;
                    // Apply force to projectile
                    Vector3 forceOrientation = new Vector3(transform.rotation.x, transform.rotation.y, transform.rotation.z) + transform.forward;
                    projectile.GetComponent<Rigidbody>().AddForce(forceOrientation * bulletComponent.GetSpeed(), ForceMode.Impulse);
                    // Set when projectile is destroyed
                    Destroy(projectile, bulletComponent.GetLifeSpan());

                    bulletStock--;

                    break;
                }
            }
        }*/
    }
    
}
