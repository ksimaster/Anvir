using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADSScript : MonoBehaviour
{

    private void Start()
    {
        if(Advertisement.isSupported)
        {
            Advertisement.Initialize("3860495", false);
        }

    }

   public void AdClick()
    {
        if (Advertisement.IsReady())
        {
            Advertisement.Show("video");
        }
    }
}
