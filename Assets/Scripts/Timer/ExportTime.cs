using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExportTime : MonoBehaviour
{
    [SerializeField] Text txtTime;
    [SerializeField] string mapName;
    float timeClear = 0;
    
    private void Start()
    {
        
    }
    private void Update()
    {
        timeClear += Time.deltaTime;
        float minutes = Mathf.Floor(timeClear / 60);
        float seconds = Mathf.RoundToInt(timeClear % 60);

        if (txtTime.IsActive())
        {
            if (timeClear < PlayerPrefs.GetFloat(mapName))
            {
                PlayerPrefs.SetFloat(mapName, timeClear);
            }            
        }
        if (seconds < 10)
        {
            txtTime.text = minutes + ":0" + seconds;
        }
        else
            txtTime.text = minutes + ":" + seconds; 
    }
}
