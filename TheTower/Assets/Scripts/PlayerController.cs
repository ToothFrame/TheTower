using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    [SerializeField] private KeyCode userKeyRight = KeyCode.RightArrow, userKeyLeft = KeyCode.LeftArrow, userKeyUp = KeyCode.UpArrow, userKeySpace = KeyCode.Space;
    [SerializeField] private float f_speed = 10f;
    public float jumpForce;
    private Rigidbody2D rigidBody;
    private bool isOnGround;
    public Transform feetPosition;
    public float checkRadius;
    public LayerMask ground;
    [SerializeField] float f_jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;
    [SerializeField] private float f_attackCooldownTimer;
    [SerializeField] private float f_attackCooldown;
    public AudioSource hammerSwing;


    void FixedUpdate(){
        if(Input.GetKey(userKeyRight)){
            transform.position += transform.right * f_speed * Time.deltaTime;
        }
        if(Input.GetKey(userKeyLeft)){
            transform.position -= transform.right * f_speed * Time.deltaTime;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        isOnGround = Physics2D.OverlapCircle(feetPosition.position, checkRadius, ground);
        if(isOnGround == true && Input.GetKeyDown(userKeyUp)){
        isJumping = true;
        f_jumpTimeCounter = jumpTime;
            rigidBody.velocity = Vector2.up * jumpForce;
        }
        if(Input.GetKey(KeyCode.UpArrow) && isJumping == true){
            if(f_jumpTimeCounter > 0) {
                rigidBody.velocity = Vector2.up * jumpForce;
                f_jumpTimeCounter -= Time.deltaTime;
            } else {
                isJumping = false;
            }
        }
        if(Input.GetKeyUp(KeyCode.UpArrow)){
            isJumping = false;
        }



        if(Input.GetKeyDown(userKeySpace) && f_attackCooldown <= 0){
            f_attackCooldown = f_attackCooldownTimer;
            print("you attacked");
            hammerSwing.Play();
        } else {
            f_attackCooldown -= Time.deltaTime;
            if(Input.GetKeyDown(userKeySpace)){
                print("hold on");
            }
        }
    }
}
