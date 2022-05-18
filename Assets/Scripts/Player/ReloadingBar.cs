using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReloadingBar : MonoBehaviour
{
    Transform target;

    private void Awake()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, new Vector2 (target.position.x, target.position.y+0.2f), 1.5f * Time.deltaTime);
    }
}
