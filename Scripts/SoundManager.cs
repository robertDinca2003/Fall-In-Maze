using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Image soundOnIcon;


    [SerializeField]  Image soundOffIcon;
    public bool muted = false;

    public void onBtnPressed()
    {
        if(muted == true)
        {
         AudioListener.pause = false;  
         muted =false;
        }
        else
        {
            AudioListener.pause = true;
            muted = true;
        }
        Save();
        updateBtn();
        
        
    }

    private void Load()
    {
        muted = PlayerPrefs.GetInt("muted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.SetInt("muted", muted?1:0);
    }

    void Start()
    {
        if(!PlayerPrefs.HasKey("muted")){
            PlayerPrefs.SetInt("muted",0);
            Load();
        }
        else
        {
            Load();
        }
        updateBtn();
        AudioListener.pause = muted;
    }

    // Update is called once per frame
    public void updateBtn()
    {
        Load();
        if(muted == true)
        {
          
         soundOnIcon.gameObject.SetActive(false);
         soundOffIcon.gameObject.SetActive(true) ;
        }
        else
        {
            
         soundOnIcon.gameObject.SetActive(true);
         soundOffIcon.gameObject.SetActive(false) ;
        }
    }
    void Update()
    {
        updateBtn();
    }
}
