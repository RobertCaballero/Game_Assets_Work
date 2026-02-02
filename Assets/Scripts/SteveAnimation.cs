using UnityEngine;

public class SteveAnimation : MonoBehaviour
{

    public Rigidbody2D rigidBody;
    public Animator animator;
    public Camera follow;

    private Vector2 input;
    public float speed = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        input.Normalize();

        animator.SetFloat("Horizontal", input.x);
        animator.SetFloat("Vertical", input.y);

    }

    private void FixedUpdate()
    {
        rigidBody.linearVelocity = input * speed;
    }
}
