using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coyote : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] GameObject coyoteBullet, player;
    [SerializeField] AudioSource laugh, damamgedSFX, blinkSFX;

    public float speed = 1f;
    public int maxHealth = 2;

    int direction = 1;
    float blinkDirection = -1.5f;

    bool isMoving = true;

    public int health { get { return currentHealth; } }
    int currentHealth;

    Animator animator;

    Rigidbody2D rg2d;
    SpriteRenderer sr;
    Material originalMaterial;
    Coroutine flashRoutine;

    float stopMovingTimer;
    float idleTimer;

    float shootTimer;
    int blinkCount;

    void Start()
    {
        shootTimer = Time.time; 
        blinkCount = 0;
        //Set target to player
        rg2d = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        originalMaterial = sr.material;
        damamgedSFX = GetComponent<AudioSource>();

        //GetComponent
        animator = GetComponent<Animator>();
        //Health
        currentHealth = maxHealth;

    }

    void Update()
    {
        
        
        //Randomly StopMoving
        animator.SetBool("isMoving", isMoving);
        if (stopMovingTimer > 8)
        {

            isMoving = false;
            blinkCount += 1;
            laugh.Play();
            idleTimer = 3f;
            speed = 0f;
            stopMovingTimer = -3;
        }

        idleTimer -= Time.deltaTime;
        if (idleTimer < 0 && isMoving == false)
        {
            speed = 1f;
            idleTimer = 3;
            isMoving = true;
            shootTimer = Time.time;
        }

        // Blink every 2 times;
        if (blinkCount >= 2 && isMoving == false)
        {
            blinkSFX.Play();
            transform.position = new Vector2(rg2d.position.x + blinkDirection, rg2d.position.y );
            blinkDirection = -blinkDirection;
            blinkCount = 0;
        }
        


        //Die
        if (currentHealth == 0)
        {
            isMoving = false;
            speed = 0;
            animator.SetTrigger("die");
            Destroy(gameObject, 0.5f);
        }


    }

    void FixedUpdate()
    {
        stopMovingTimer += Time.deltaTime;
        

        if (isMoving == true && Time.time > shootTimer)
        {
            shootTimer += 0.2f;
            GameObject bullet = Instantiate(coyoteBullet, rg2d.transform.position, Quaternion.identity);
            Rigidbody2D rbBullet = bullet.GetComponent<Rigidbody2D>();
            rbBullet.AddForce(-transform.right * 0.8f, ForceMode2D.Impulse);
        }

        Vector2 position = rg2d.position;
        position.y = position.y + Time.deltaTime * speed * direction; 
        rg2d.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            ChangeHealth(-1);
        }
        if (currentHealth == 0)
        {
            player.GetComponent<Player>().money += 50;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tiltes")
        {
            direction = -direction;
        }


    }
    private void ChangeHealth(int amount)
    {
        Flash();
        damamgedSFX.Play();
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }


    IEnumerator FlashRoutine()
    {
        sr.material = flashMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = originalMaterial;
        flashRoutine = null;
    }



    void Flash()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
}


