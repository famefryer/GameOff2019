using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight;
    public int health;

    public Rigidbody2D rg;
    public Vector2 colliderSize;

    public Transform groundCheckObject;
    public Transform attackRangeCenter;

    public LayerMask obstacleLayer;
    public LayerMask groundLayer;

    public PlayerAnimationController animationController;
    public PlayerAttackBehavior playerAttackBehavior;

    private Vector2 startedPosition;
    private bool isJumping;
    private bool isSpecialMoveActivated;
    private bool isAttacking;

    // Start is called before the first frame update
    void Start()
    {
        startedPosition = transform.position;
        playerAttackBehavior = new PlayerAttackBehavior(attackRangeCenter,colliderSize,obstacleLayer);
    }

    // Update is called once per frame
    void Update()
    {
        //Check jump
        if(isJumping && GroundedCheck())
        {
            isJumping = false;
        }

        //Check attack
        if (isAttacking)
        {
            if (!animationController.isAnimationRunning)
            {
                isAttacking = false;
            }
            playerAttackBehavior.colliderChecked();
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
            isAttacking = true;
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
