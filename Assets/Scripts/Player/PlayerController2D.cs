using UnityEngine;

public class PlayerController2D : MonoBehaviour
{
    #region Public Variables
    [Header("Life Stats")] 
    public float healthCurrent = 100;
    public float healthMax = 100;
    [HideInInspector] public int lifeCount;
    public Animator detectiveAnimator;
    #endregion

    #region Private Variables
    [Header("Movement")] 
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private bool facingRight = true; // For determining which way the player is currently facing.
    private float horizontal;
    private float vertical;
    private Rigidbody2D rb2D;
    private float jumpPressed = 0;
    private float jumpPressedTime = 0.2f;
    #endregion
    
    // Start is called before the first frame update
    void Start() {
        detectiveAnimator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
        HudDisplay.instance.UpdateHearts(healthCurrent, healthMax);
    }

    // Update is called once per frame
    void Update() {
        #region Walking
        //If horizontal input is not 0 and current animation state is not idle
        if (horizontal != 0)
        {
            //Walk animation
            detectiveAnimator.SetBool("isWalk", true);
        }
        else
        {
            detectiveAnimator.SetBool("isWalk", false);
        }
        #endregion

        Move();
        FlipSprite();

        #region Jumping

        jumpPressed -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jumpPressed = jumpPressedTime;
        }

        if (jumpPressed > 0 && Mathf.Abs(rb2D.velocity.y) < 0.001f)
        {
            jumpPressed = 0;
            Jump();
        }

        #endregion
    }

    private void LateUpdate() {
        HealthBoundary();
        HudDisplay.instance.UpdateHearts(healthCurrent, healthMax);
    }

    public void HealthBoundary() {
        lifeCount = 0;
        if (healthCurrent >= healthMax)
        {
            healthCurrent = healthMax;
        }
        else if (healthCurrent <= 0)
        {
            lifeCount++;
            LevelManager.instance.RespawnPlayer();
        }
    }

    public void Move() {
        horizontal = Input.GetAxis("Horizontal");
        rb2D.velocity = new Vector2((horizontal) * moveSpeed, rb2D.velocity.y);
    }

    public void Jump() {
        rb2D.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void FlipSprite() {
        if ((horizontal < 0 && facingRight) || (horizontal > 0 && !facingRight))
        {
            facingRight = !facingRight;
            transform.Rotate(new Vector3(0, 180, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.CompareTag("Collectable"))
        {
            HudDisplay.instance.UpdateScore();
        }
    }

    /// <summary>
    /// Register collisions made with the player to cause damage.
    /// </summary>
    private void OnCollisionEnter2D(Collision2D other) {
        #region Take Damage

        if (other.gameObject.CompareTag("Obstacle"))
        {
            print("Colliding with Spikes, ouch!");
            TakeDamage(2f);
        }

        if (other.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(5f);
        }
        #endregion
    }

    public void TakeDamage(float damage) {
        healthCurrent -= damage;
        HudDisplay.instance.UpdateHearts(healthCurrent, healthMax);
    }

    public void TestHealth() {
        if (Input.GetKeyDown(KeyCode.X))
        {
            healthCurrent -= 5;
            HudDisplay.instance.UpdateHearts(healthCurrent, healthMax);
        }
    }
}