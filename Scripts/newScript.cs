using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class newScript : MonoBehaviour
{
    public bool pressed = false ;
    public Button pause;
    public Button back;
    public Button left ;
    public Button right;

    public Button skipLvl;
    public Button restartbtn;
    public RawImage img;

    public Text lblDef;
    public Button btnMusic;

   // float fixedDeltaTime;
    // Start is called before the first frame update
    void Awake()
    {
        //this.fixedDeltaTime = Time.fixedDeltaTime;
    }
    void Start()
    {
        pause.onClick.AddListener(btnPressed);
    }


    public void backbtn()
    {
        pressed = false ;
    }
    public void btnPressed()
    {
        gameObject.GetComponent<Button>().enabled = true;
        if(pressed == false)
        {
            
            back.gameObject.SetActive(true);
            left.enabled = false ;
            right.enabled = false ;
            restartbtn.gameObject.SetActive(true);
            img.gameObject.SetActive(true);
            btnMusic.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            back.gameObject.SetActive(false);
            left.enabled = true ;
            right.enabled = true ;
            restartbtn.gameObject.SetActive(false);
            img.gameObject.SetActive(false);
            btnMusic.gameObject.SetActive(false);
            skipLvl.gameObject.SetActive(false);
            lblDef.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
        pressed = !pressed;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
