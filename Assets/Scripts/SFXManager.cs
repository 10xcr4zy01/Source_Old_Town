using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public AudioSource shoot, reload, damaged, pickup, outofammo;

    public void PlaySound (string nameSound)
    {
        switch (nameSound)
        {
            case "shoot":
                shoot.Play();
                break;
            case "reload":
                reload.Play();
                break;
            case "damaged":
                damaged.Play();
                break;
            case "pickup":
                pickup.Play(); 
                break ;
            case "outofammo":
                outofammo.Play();
                break;

        }
    }
    
}
