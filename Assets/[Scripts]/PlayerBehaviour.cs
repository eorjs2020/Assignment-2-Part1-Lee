//PlayerBehaviour
//LastUpdate 22_11_21
//Daekoen_Lee 101076401
//Revision History
//First modified 22_12_11 - added Sound
//Description - Player Behavior (Move, jump, attack, animation Controller)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Movement Properties")]
    public float horizontalForce;
    public float horizontalSpeed;

    public float verticalForce;
    public float airFactor;
    public Transform groundPoint; // the origin of the circle
    public float groundRadius; // the size of ths circle
    public LayerMask groundLayerMask; // the stuff we can collide with
    public bool isGrounded;

    [Header("Animator")]
    public Animator animator;
    public PlayerAnimationState state;

    [Header("Controls")]
    public Joystick LeftStick;
    [Range(0.1f, 1.0f)]
    public float verticalTrheshhold;
    public bool isAttack;
    private Rigidbody2D rigid2D;

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRadius;
    public LayerMask enemyLayer;
    private float nextAttack;
    public float attackRate = 2f;

    private float damageTimer;
    private bool isDamage;
    // Start is called before the first frame update
    void Start()
    {
        isAttack = false;
        damageTimer = 0f;
        isDamage = false;
        Data.Instance.ResetHealth();
        GameController.Instance.ChangeHealth();
        nextAttack = 0.0f;
        rigid2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        LeftStick = (Application.isMobilePlatform) ? GameObject.Find("LeftStick").GetComponent<Joystick>() : null;
        SoundManager.Instance.PlayMusic(Sound.MAIN_MUSIC);
    }

    private void Update()
    {     
        
        
        if (Input.GetKeyDown(KeyCode.J))
        {
            Attack();
        }
        
        
        if (isDamage)
        {
            if (damageTimer <= 1.0f)
            {
                damageTimer += Time.time;
            }
            if (damageTimer >= 1.0f)
            {
                damageTimer = 0.0f;
                isDamage = false;
            }
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        var hit = Physics2D.OverlapCircle(groundPoint.position, groundRadius, groundLayerMask);
        isGrounded = hit;
        if (!isAttack)
        {
            Move();
            Jump();
        }
        AirCheck();
    }

    public void Attack()
    {
        if (Time.time >= nextAttack)
        {
            isAttack = false;
            animator.SetTrigger("Attack");
            SoundManager.Instance.PlaySoundFX(Sound.ATTACK, Chanel.PLAYER_SOUND_FX);
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRadius, enemyLayer);

            foreach (Collider2D enemy in enemies)
            {
                enemy.gameObject.GetComponent<EnemyController>().GetDamage();
            }
            nextAttack = Time.time + 1f / attackRate;
        }
        
        
    }

    public void ButtonAttack()
    {
        if (!isAttack)
        {
            isAttack = true;
            Attack();            
        }
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal") + ((Application.isMobilePlatform) ? LeftStick.Horizontal : 0.0f);
        if (x != 0)
        {
            Flip(x);

            x = (x >0.0) ? 1.0f : -1.0f;
            rigid2D.AddForce(Vector2.right * x * horizontalForce * ((isGrounded) ? 1.0f : airFactor));

            //rigid2D.velocity = Vector2.ClampMagnitude(rigid2D.velocity, horizontalSpeed);

            var clampXVelocity = Mathf.Clamp(rigid2D.velocity.x, -horizontalSpeed, horizontalSpeed);

            rigid2D.velocity = new Vector2(clampXVelocity, rigid2D.velocity.y);

            ChangeAnimation(PlayerAnimationState.RUN);
        }

        if((isGrounded) && (x == 0))
        {
            ChangeAnimation(PlayerAnimationState.IDLE);
        }
    }

    public void Flip(float x)
    {
        if( x != 0.0f)
        {
            transform.localScale = new Vector3((x > 0.0f) ? 1.0f : -1.0f, 1.0f, 1.0f);
        }
    }

    private void Jump()       
    {
        var y = Input.GetAxis("Jump") + ((Application.isMobilePlatform) ? LeftStick.Vertical : 0.0f);        
        if ((isGrounded) && (y > verticalTrheshhold))
        {
            SoundManager.Instance.PlaySoundFX(Sound.JUMP, Chanel.PLAYER_SOUND_FX);
            rigid2D.AddForce(Vector2.up * verticalForce, ForceMode2D.Impulse);
        }
    }

    private void AirCheck()
    {
        if(!isGrounded)
        {
            ChangeAnimation(PlayerAnimationState.JUMP);
        }
    }

    private void ChangeAnimation(PlayerAnimationState playerAnimationState)
    {        
        state = playerAnimationState;
        animator.SetInteger("AnimationState", (int)state);
    }

    public void GetDamage()
    {
        if (!isDamage && !isAttack)
        {
            SoundManager.Instance.PlaySoundFX(Sound.HURT, Chanel.PLAYER_HURT_FX);
            isDamage = true;
            Data.Instance.health -= 1;
            GameController.Instance.ChangeHealth();
            if (Data.Instance.health <= 0)
            {
                SceneManager.LoadScene("ScoreScene");
            }
            
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if (attackPoint != null)
        {
            Gizmos.DrawWireSphere(attackPoint.position, attackRadius);
        }

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundPoint.position, groundRadius);
    }

}
