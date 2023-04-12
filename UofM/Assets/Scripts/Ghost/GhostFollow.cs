using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostFollow : MonoBehaviour
{
  
    public GameObject Object;

    public GameObject followTarget;
    private Vector3 targetPos;
    public float moveSpeed;

    private Animator anim;
    private Rigidbody2D myBody;
    //private CircleCollider2D GhostCollider;

    private bool playerMoving;
    private Vector2 lastMove;
    int trigger;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        myBody = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal")
            // * moveSpeed * Time.deltaTime, 0f, 0f));

            myBody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed, myBody.velocity.y);

            playerMoving = true;

            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }


        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //transform.Translate(new Vector3(0f,Input.GetAxisRaw("Vertical")
            // * moveSpeed * Time.deltaTime, 0f));

            myBody.velocity = new Vector2(myBody.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed);


            playerMoving = true;

            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
        {
            myBody.velocity = new Vector2(0f, myBody.velocity.y);
        }

        if (Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
        {
            myBody.velocity = new Vector2(myBody.velocity.x, 0f);
        }

        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);


    }
   
 void OnTriggerStay2D(Collider2D other)
        {
            if (other.gameObject.name == "Player")
            {
                
            trigger= 1;

            }
        }

    // Update is called once per frame
    void Update()
    {
        if (trigger == 1)
        {
            Move();
            targetPos = new Vector3(followTarget.transform.position.x,
                                    followTarget.transform.position.y,
                                    transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);

        }
     

    }
}
 