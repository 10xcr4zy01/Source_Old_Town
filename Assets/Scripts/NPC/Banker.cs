using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Banker : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Player player;
    [SerializeField] Text txtBankAmount;
    int bankAmount;

    private void Update()
    {
        bankAmount = PlayerPrefs.GetInt("bankAmount");
        txtBankAmount.text = bankAmount.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            menu.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
            menu.SetActive(false);
    }

    public void Deposit ()
    {
        bankAmount += player.money;
        PlayerPrefs.SetInt("bankAmount", bankAmount);
        PlayerPrefs.SetInt("money", 0);
        player.money = 0;
    }

    public void Withraw()
    {
        player.money += bankAmount;
        PlayerPrefs.SetInt("money", player.money);
        PlayerPrefs.SetInt("bankAmount", 0);
    }


}
