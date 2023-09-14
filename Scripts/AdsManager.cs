using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        Advertisement.Initialize("4917685");
    }
    public void PlayAd()
    {
           
            Advertisement.Show("Interstitial_Android");
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
