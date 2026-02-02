using UnityEngine;
using UnityEngine.Rendering;

public class BuddyController : MonoBehaviour
{

    [SerializeField] private Rigidbody2D rigidBody; //Manage stuff in the inspector :D
    public Animator animator;
    public SpriteRenderer spriteRenderer;

    private float inputX;
    private bool jumpPressed;
    private bool isGrounded;
    private float facing = 1; //1 = right , -1 = left
    public float moveSpeed = 5;
    public float jumpForce = 10;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        inputX = Input.GetAxisRaw("Horizontal");

        // Set facing direction

        if (inputX > 0)
        {
            facing = 1;
        }
        else if (inputX < 0)
        {
            facing = -1;
        }

        //flip the sprited based on left/right
        if (facing >= 0.01)
        {
            spriteRenderer.flipX = false;
        }
        else if (facing <= -0.01)
        {
            spriteRenderer.flipX= true;
        }

        if (Input.GetButtonDown("Jump"))
        {
            rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse); //We add a force to the rigid body so it lifts the character upwards 
        }


    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocityX = inputX * moveSpeed;


    }
}
