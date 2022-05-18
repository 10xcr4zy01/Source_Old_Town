using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapSelectRecord : MonoBehaviour
{
    public string mapName;
    Text txtRecord;
    float timeRecord;

    private void Awake()
    {
        txtRecord = GetComponent<Text>();
        timeRecord = PlayerPrefs.GetFloat(mapName);
        float minutes = Mathf.Floor(timeRecord / 60);
        float seconds = Mathf.RoundToInt(timeRecord % 60);
        if (PlayerPrefs.GetFloat(mapName) != 9999)
        {
            if (seconds < 10)
            {
                txtRecord.text = "Record: " + minutes + ":0" + seconds;
            }
            else
                txtRecord.text = "Record: " + minutes + ":" + seconds;
        }
            

        
        
    }

        
}
