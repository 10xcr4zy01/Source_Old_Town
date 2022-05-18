using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] private GameObject effect;


    void OnTriggerEnter2D(Collider2D col)
    {
        //Flash();
        Destroy(Instantiate(effect, transform.position, transform.rotation), 0.2f);
        Destroy(gameObject);
        
    }

}
