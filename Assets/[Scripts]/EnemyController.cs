using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [Header("Movement Properties")]
    
    public float horizontalSpeed;
    public Transform inFrontPoint;
    public Transform aheadPoint;    
    public Transform groundPoint; // the origin of the circle
    public float groundRadius; // the size of ths circle
    public LayerMask groundLayerMask; // the stuff we can collide with
    public bool isObstacleAhead;
    public bool isGroundAhead;
    public bool isGrounded;
    public Vector2 direction;

    public float enemyHealth;
    
    private Animator animator;
    private bool isDamage;
    private float timer;

    void Start()
    {        
        timer = 0.0f;
        animator = GetComponent<Animator>();
        isDamage = false;
        enemyHealth = 100.0f;
        direction = Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDamage)
        {
            isObstacleAhead = Physics2D.Linecast(groundPoint.position, inFrontPoint.position, groundLayerMask);
            isGroundAhead = Physics2D.Linecast(groundPoint.position, aheadPoint.position, groundLayerMask);
            isGrounded = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayerMask);

            if (isGrounded && isGroundAhead)
            {
                Move();
            }
            if (isObstacleAhead || !isGroundAhead)
            {
                Flip();
            }
        }
        else
        {
            if (timer <= 1.0f)
            {
                timer += Time.deltaTime;
            }
            if(timer >= 1.0f)
            {
                timer = 0.0f;
                animator.SetTrigger("Normal");
                isDamage = false;
            }
        }
    }

    public void Move()
    {
        transform.position += new Vector3(direction.x * horizontalSpeed * Time.deltaTime, 0.0f);
    }

    public void Flip()
    {
        var x = transform.localScale.x * -1.0f;
        direction *= -1.0f;
        transform.localScale = new Vector3(x, 1.0f, 1.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            gameObject.GetComponent<PlayerBehaviour>();
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
        Gizmos.DrawLine(groundPoint.position, inFrontPoint.position);
        Gizmos.DrawLine(groundPoint.position, aheadPoint.position);
    }

    public void GetDamage()
    {
        
        if (!isDamage)
        {
            animator.SetTrigger("Damaged");
            isDamage = true;
            enemyHealth -= 50.0f;
            if(enemyHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
