using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sheriff : MonoBehaviour
{
    [SerializeField] GameObject menu;
    [SerializeField] Text txtAbout;
    [SerializeField] GameObject btnClaim;
    [SerializeField] Player player;
    int state;
    private void Awake ()
    {
        
    }

    private void Update()
    {
        state = PlayerPrefs.GetInt("QuestState");
        ListQuest(state);
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

    private void ListQuest (int state)
    {
        switch (state)
        {
            case 0:
                txtAbout.text = "Clear map Cemetery!";
                btnClaim.GetComponent<Button>().interactable = PlayerPrefs.GetFloat("cemetery") < 9998 ? true : false;
                break;
            case 1:
                txtAbout.text = "Defeat Coyote!";
                btnClaim.GetComponent<Button>().interactable = PlayerPrefs.GetFloat("coyote") < 9998 ? true : false;
                break;
            case 2:
                txtAbout.text = "Clear map Cemetery less than 2 minutes!";
                btnClaim.GetComponent<Button>().interactable = PlayerPrefs.GetFloat("cemetery") < 120 ? true : false;
                break;
            case 3:
                txtAbout.text = "Defeat Coyote less than 2 minutes!";
                btnClaim.GetComponent<Button>().interactable = PlayerPrefs.GetFloat("coyote") < 9998 ? true : false;
                break;
            case 4:
                txtAbout.text = "Clear map Cemetery less than 50 second!";
                btnClaim.GetComponent<Button>().interactable = PlayerPrefs.GetFloat("cemetery") < 50 ? true : false;
                break;
            case 5:
                txtAbout.text = "Defeat Coyote less than 1 minute !";
                btnClaim.GetComponent<Button>().interactable = PlayerPrefs.GetFloat("coyote") < 60 ? true : false;
                break;
            case 6:
                txtAbout.text = "You have completed all the quests";
                btnClaim.SetActive(false);
                break;

        }
    }


    public void ClaimButtonClickEvent ()
    {
        player.GetComponent<Player>().money += 100;
        PlayerPrefs.SetInt("money", player.GetComponent<Player>().money);
        PlayerPrefs.SetInt("QuestState", state+1);
        state = PlayerPrefs.GetInt("QuestState");
    }



 
}

