using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonClickEvent : MonoBehaviour
{
    public AudioSource click;

    private void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
    public void Exits ()
    {
        click.Play();
        Application.Quit();
    }

    public void SwtichScenes(string nameScene)
    {
        click.Play();
        SceneManager.LoadScene(nameScene);
    }

    public void SwtichScenesAndSave(string nameScene)
    {
        click.Play();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<Player>().SaveStats();
        SceneManager.LoadScene(nameScene);
    }

    public void OpenMenu (GameObject menuObject)
    {
        click.Play();
        menuObject.SetActive(true);
    }

    public void CloseMenu(GameObject menuObject)
    {
        click.Play();
        menuObject.SetActive(false);
    }

    public void ClearData (GameObject menu)
    {
        PlayerPrefs.DeleteAll();
        menu.SetActive(false);
       
    }

    public void SetSettingDefault (Dropdown resolutionDropdown)
    {
        int fullScreenValue = Screen.fullScreen ? 1 : 0;
        PlayerPrefs.SetInt("isFullScreen", fullScreenValue);
        PlayerPrefs.SetInt("currentResolitionIndex", resolutionDropdown.value);
    }

}
