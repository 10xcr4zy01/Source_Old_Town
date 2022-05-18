using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseScript : MonoBehaviour
{
    [SerializeField]
    GameObject
        winMenu,
        loseMenu,
        player,
        winCondition;
    float timer;

    private void Awake()
    {
        timer = 3f;
    }

    private void Update()
    {
        if (winMenu.activeSelf == false && loseMenu.activeSelf == false)
        {
            Time.timeScale = 1f;
        }

        //Lose
        if (player.GetComponent<Player>().health == 0)
        {
            player.GetComponent<Player>().money = 0;
            Open(2);
        }

        //Win
        if (winCondition.activeSelf == true)
        {
            timer -= Time.deltaTime;
            if (GameObject.FindWithTag("Enemy") == true)
            {
                timer = 2f;
            }
            if (timer < 0)
            {
                Open(1);
            }
        }
        
    }

    private void Open (int i)
    {
        switch (i)
        {
            case 1:
                winMenu.SetActive(true);
                Pause();
                break;
            case 2: 
                loseMenu.SetActive(true);
                Pause();
                break;
        }
    }

    private void Pause ()
    {
        Time.timeScale = 0.000001f; 
    }
}
