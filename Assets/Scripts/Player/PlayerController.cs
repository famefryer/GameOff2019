using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpHeight;
    public int maxHealth;
    public int maxMana;

    public Rigidbody2D rg;
    public Vector2 attackColliderSize;

    public Transform groundCheckCenter;
    public Transform attackRangeCenter;

    public LayerMask obstacleLayer;
    public LayerMask groundLayer;

    public PlayerAnimationController animationController;
    public PlayerAttackBehavior playerAttackBehavior;

    private Vector2 startedPosition;
    private bool isJumping;
    private bool isSpecialMoveActivated;
    private bool isAttacking;
    private bool isGrounded;

    //UI
    [SerializeField]
    private BarController healthBarController;
    [SerializeField]
    private BarController manaBarController;

    [HideInInspector]
    public bool isDead;
    [HideInInspector]
    public int currentHealth;
    [HideInInspector]
    public int currentMana;

    // Start is called before the first frame update
    void Start()
    {
        startedPosition = transform.position;
        playerAttackBehavior = new PlayerAttackBehavior(attackRangeCenter,attackColliderSize,obstacleLayer);
        currentHealth = 10;
        currentMana = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        //Check Jump
        isGrounded = GroundedCheck();
        if(isJumping && isGrounded)
            isJumping = false;

        //Check attack
        if (isAttacking)
        {
            //Check is attack is completed.
            if (!animationController.isAnimationRunning)
            {
                isAttacking = false;
                gainMana(playerAttackBehavior.getMana());
            }
            playerAttackBehavior.colliderChecked();
        }

        //Input region
        //Jump
        if(!isJumping && Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rg.AddForce(new Vector2(0, jumpHeight));
            isJumping = true;
        }

        // Special movement
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (IsManaEnoughToUse(5))
            {
                currentMana -= 5;
                manaBarController.updateValue(currentMana, 0, maxMana);
            }
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
        return Physics2D.OverlapCircle(groundCheckCenter.position,0.1f, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FallingCollision"))
        {
            isDead = true;
        }
    }

    private void gainMana(int mana)
    {
        if(currentMana + mana <= maxMana)
            currentMana += mana;
        manaBarController.updateValue(currentMana, 0, maxMana);
    }

    public bool IsManaEnoughToUse(int manaRequired)
    {
        if(currentMana - manaRequired >= 0)
        {
            return true;
        }
        return false;
    }

    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        healthBarController.updateValue(currentHealth, 0, maxHealth);
        if (currentHealth <= 0)
        {
            isDead = true;
        }
    }

    public void resetPlayer()
    {
        transform.position = startedPosition;
        isDead = false;
        currentHealth = 10;
        currentMana = 0;
    }

}
