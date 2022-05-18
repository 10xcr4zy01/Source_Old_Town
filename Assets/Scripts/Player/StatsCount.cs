using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsCount : MonoBehaviour
{
    [SerializeField] private string nameStat;
    Player player;

    int currentStat;
    int maxStat;  
    Text txt;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        txt = GetComponent<UnityEngine.UI.Text>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (nameStat)
        {
            case "Bullet":
                maxStat = player.maxBullets;
                currentStat = player.bullet;
                txt.text = currentStat.ToString() + "/" + maxStat.ToString();
                break;
            case "Heart":
                maxStat = player.maxHealth;
                currentStat = player.health;
                txt.text = currentStat.ToString() + "/" + maxStat.ToString();
                break;
            case "Money":
                currentStat = player.money;
                txt.text = currentStat.ToString();
                break;

        }       
    }
}   
