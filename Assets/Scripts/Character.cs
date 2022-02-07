using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Rigidbody2D player;
    public float speed = 30.0f;
    public float jumpHeight = 10f;
    public Chest silverChest;
    public bool startAction;
    public Animator animation;
    //public SpriteRenderer body;
    public CapsuleCollider2D capsuleCollider2d;

    //private Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
       // body = GetComponent<SpriteRenderer>();
        startAction = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrounded() && Input.GetKeyDown("space"))
            characterJump();

        if (Input.GetKeyUp("space"))
            animation.ResetTrigger("Jumping");

        if (Input.GetKeyDown("x"))
        {
            startAction = true;
            Debug.Log("X key was pressed");
            Debug.Log(startAction);
        }

        if (Input.GetKeyDown("e"))
        {
            attack();
        }

        if (Input.GetKeyUp("e"))
            animation.ResetTrigger("Attacking");

    }

    void FixedUpdate()
    {
        var movement = Input.GetAxis("Horizontal");
        if (movement != 0)
        {
            if (movement > 0)
            {
                //Debug.Log(player.position);
                movement *= speed;
                player.velocity = new Vector2(+movement, player.velocity.y) * Time.fixedDeltaTime;
                //player.MovePosition(player.position + new Vector2(movement, 0) * Time.deltaTime);
                animation.SetBool("Running", true);
            }
            else
            {
               // body.flipX = true;
                animation.SetBool("Running", true);
            }
        }
        else
            animation.SetBool("Running", false);
    }

    void attack()
    {
        animation.SetTrigger("Attacking");
    }


    void characterJump()
    {
        //player.position = Vector2.up(0, jump * jumpHeight);
        player.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
        animation.SetTrigger("Jumping");
       // Debug.Log("Your character jumped by: " + player.position.y);
    }

    private bool IsGrounded()
    {
        float extraHeight = .01f;
        RaycastHit2D raycastHit = Physics2D.Raycast(capsuleCollider2d.bounds.center,Vector2.down,capsuleCollider2d.bounds.extents.y + extraHeight);
        Color rayColor;

        if (raycastHit.collider != null)
        {
            rayColor = Color.green;
            //Debug.Log(raycastHit);
        }
        else
        {
            rayColor = Color.red;
        }
      
        Debug.DrawRay(capsuleCollider2d.bounds.center, Vector2.down * (capsuleCollider2d.bounds.extents.y + extraHeight));

        return raycastHit.collider != null;
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "breakable")
        {
            Destroy(collider.gameObject);
        }

        if(collider.gameObject.tag == "openable" && startAction == true)
        {
            Debug.Log("Entered Trigger");
            silverChest.OpenChest();

        }
    }

}

