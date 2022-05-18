using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTilemap : MonoBehaviour
{
    [SerializeField] private GameObject spawner, player, gate, arrow;
    [SerializeField] private int postionToMove;

    Transform cameraTransform;

    bool isTriggered;
    bool isTriggeredYet;

    float timer;


    private void Awake()
    {
       isTriggered = false;
       isTriggeredYet = false;
       timer = 3f;
       cameraTransform = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }

    private void Update()
    {
        if (GameObject.FindWithTag("Enemy") == true)
        {
            timer = 3f;
        }

        timer -= Time.deltaTime;
        if (timer < 0 && isTriggeredYet == false)
        {
            arrow.SetActive(true);
            isTriggered = true;
            gate.SetActive(false);
        }
        else
        {
            arrow.SetActive(false);
            isTriggered = false;
            gate.SetActive(true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (isTriggered == true)
        {
            isTriggeredYet = true;
            MovingCamera();
            spawner.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
            isTriggered = false;
            gate.SetActive(true);
    }

    private void MovingCamera ()
    {
        player.transform.position = new Vector2(player.transform.position.x, player.transform.position.y - 1f);
        Vector3 moveToPosition = new Vector3(0, postionToMove, -10);
        cameraTransform.transform.position = Vector3.Lerp(transform.position, moveToPosition, 2f);
    }
}
