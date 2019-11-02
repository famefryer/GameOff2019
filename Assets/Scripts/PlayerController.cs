using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight;
    public Rigidbody2D rg;
    public Transform groundCheckObject;
    public LayerMask groundLayer;
    public PlayerAnimationController animationController;

    private Vector2 startedPosition;
    private bool isJumping;
    private bool isSpecialMoveActivated;

    // Start is called before the first frame update
    void Start()
    {
        startedPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Check jump position reach
        if(isJumping && GroundedCheck())
        {
            isJumping = false;
        }

        //Input region
        //Jump
        if(!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            rg.AddForce(new Vector2(0, jumpHeight));
            isJumping = true;
        }

        // Special movement
        if (Input.GetKeyDown(KeyCode.S))
        {

        }

        //Normal Attack 
        if (Input.GetKeyDown(KeyCode.D))
        {
            animationController.PlayAttack();
        }


        if (Input.GetKeyDown(KeyCode.A))
        {

        }
        //end
    }

    private bool GroundedCheck()
    {
        return Physics2D.OverlapCircle(groundCheckObject.position,0.1f, groundLayer);
    }
}
