using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public int damage;
    public float speed;

    public Animator animator;
    public GameObject explosionEffect;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        explosionEffect.transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();
            if(playerController != null) playerController.takeDamage(damage);
        }
    }

    public void DestroyItself()
    {
        animator.SetTrigger("Death");
        Animator exAnimator = explosionEffect.GetComponent<Animator>();
        explosionEffect.SetActive(true);
        exAnimator.SetTrigger("Explode");
        gameObject.SetActive(false);
    }
}
