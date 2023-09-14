using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exitGame : MonoBehaviour
{

    // Start is called before the first frame update
    public void exit()
    {
       // PlayerPrefs.SetInt("currLevel",0);
        Debug.Log(PlayerPrefs.GetInt("currLevel"));
        PlayerPrefs.Save();
        Application.Quit();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
