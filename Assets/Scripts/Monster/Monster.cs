using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Monster : MonoBehaviour
{
    [SerializeField] private Material flashMaterial;
    [SerializeField] private GameObject moneyBag;

    public float speed = 0.5f;
    public int maxHealth = 3;

    public int health { get { return currentHealth; } }
    int currentHealth;

    Animator animator;

    Rigidbody2D rb;
    SpriteRenderer sr;
    Material originalMaterial;
    Coroutine flashRoutine;
    Transform target;
    AudioSource damamgedSFX;
    

    void Start()
    {
        //Set target to player
        target = GameObject.FindGameObjectWithTag("Player").transform;
        sr = GetComponent<SpriteRenderer>();
        originalMaterial = sr.material;
        damamgedSFX = GetComponent<AudioSource>();

        //GetComponent
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        //Health
        currentHealth = maxHealth;
    }

    void Update()
    {
        
        //Auto chasing player
        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);      

        //Die
        if (currentHealth == 0)
        {         
            speed = 0;
            animator.SetTrigger("die"); 
            Destroy(gameObject, 0.2f);
        }

        //Set animation
        Vector2 move = target.position - transform.position;
        animator.SetFloat("MoveX", move.normalized.x);
        animator.SetFloat("MoveY", move.normalized.y);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Weapon")
        {
            damamgedSFX.Play();
            ChangeHealth(-1);
        }

        if (health == 0)
        {
            if (Random.Range(0f, 1f) <= 0.5f)
            {
                GameObject moneyBag1 = Instantiate(moneyBag, transform.position, Quaternion.identity);
            }
        }
    }
    private void ChangeHealth(int amount)
    {
        Flash();
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
    }

    IEnumerator FlashRoutine()
    {
        sr.material = flashMaterial;
        yield return new WaitForSeconds(0.1f);
        sr.material = originalMaterial;
        flashRoutine = null;
    }


    void Flash ()
    {
        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }
        flashRoutine = StartCoroutine(FlashRoutine());
    }
}
