using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMusic : MonoBehaviour
{
    private static BGMusic bgmusic;
    // Start is called before the first frame update
     void Awake()
    {
        if(bgmusic == null)
        {
            bgmusic = this;
            DontDestroyOnLoad(bgmusic);
        }
        else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
