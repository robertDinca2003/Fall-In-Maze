using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInit : MonoBehaviour
{
    public GameObject trans;
    public int playedLevels =  0;
    public int currLevel = 0;

    //public Canvas inGameUi;
    bool death = false ;
    public RawImage img ;

    public Button btnSkipLvl;
    public Button btnBack ; 
    public Button btnLeft ; 
    public Button btnRight ; 
    public Button btnPause ; 

    public Button btnNext ;

    public Button btnRestart;

    public Text txtWin ;

    public Text txtLose;

    public Button selectedLevel;

    public Sprite movesprite;

    public Sprite idlesprite;
    
    public Sprite deathsprite;

    public Sprite[] allIdleSprite = new Sprite[5];
     public Sprite[] allMoveSprite = new Sprite[5];
      public Sprite[] allDeathSprite = new Sprite[5];

    // Start is called before the first frame update

    public void CompleteLevel(bool add)
    {
                
                
               
                
                int nr = GameObject.Find("GameMaze").GetComponent<MazeGenerator>().lastLevel;
 //               Debug.Log("--");
                Debug.Log(nr);
                selectedLevel = GameObject.Find("AllBtns").GetComponent<ButtonsUpdate>().allButons[nr-1];
                if(selectedLevel.GetComponent<Image>().color != Color.green){if(currLevel<50)currLevel++;PlayerPrefs.SetInt("currLevel",currLevel);}
                //Debug.Log(selectedLevel.GetComponent<Image>().color == Color.green);
//                Debug.Log(currLevel);
                txtWin.gameObject.SetActive(true);
                btnBack.gameObject.SetActive(true);
                if(add)btnBack.enabled =false;
                btnPause.enabled = false ;
                btnLeft.enabled = false ;
                btnPause.enabled = false ;
                
                btnRestart.gameObject.SetActive(false);
                img.gameObject.SetActive(true);
                Time.timeScale = 0f ;
                //ColorBlock cb = selectedLevel.colors;
                //cb.normalColor = Color.green;
                //cb.highlightedColor = Color.green;
                //selectedLevel.colors =cb;
                if(nr<50)
                btnNext.gameObject.SetActive(true) ;
                if(add)btnNext.enabled = false ;
                //GameObject.Find("AllBtns").GetComponent<ButtonsUpdate>().unlockLvl(GameObject.Find("GameMaze").GetComponent<MazeGenerator>().lastLevel);
                
                 if(add)
                {
                   
                   //btnRestart.enabled = false ; 
                   
                    
                   playedLevels++;
                    if(playedLevels > 0 && playedLevels % 2 == 0)GameObject.Find("AdsManager").GetComponent<AdsInitializer>().LoadInterstatialAd();
                    
                    btnBack.enabled =true;
                   //btnRestart.enabled = true ; 
                   btnNext.enabled = true ;
                }

                
                GameObject.Find("AllBtns").GetComponent<ButtonsUpdate>().selectButtons();


                
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        
            Time.timeScale = 0f;
          // Debug.Log(other.gameObject.name);
           //Debug.Log("lvl "); Debug.Log(currLevel); Debug.Log(playedLevels);
            //Debug.Log("Rada");
            //inGameUi.enabled = false;
            if(other.gameObject.name == "FinishLine")
            {
                CompleteLevel(true);
            }
            else
            {
                //Debug.Log("reed");
                death = true ;
                txtLose.gameObject.SetActive(true);
                btnBack.gameObject.SetActive(true);
               // Debug.Log(currLevel); Debug.Log(GameObject.Find("GameMaze").GetComponent<MazeGenerator>().lastLevel);
               // Debug.Log(selectedLevel.colors.normalColor == Color.green);
                if(selectedLevel.GetComponent<Image>().color != Color.green && currLevel != 50){btnSkipLvl.gameObject.SetActive(true);btnSkipLvl.enabled=true;}
                
                btnPause.enabled = false ;
                btnLeft.enabled = false ;
                btnPause.enabled = false ;
                btnPause.GetComponent<newScript>().pressed = true;
                btnRestart.gameObject.SetActive(true);
                img.gameObject.SetActive(true);
                Time.timeScale = 0f ;
                transform.GetComponent<SpriteRenderer>().sprite = deathsprite;
            }
            

    }
    
    public void selectLvl(Button btn)
    {
        selectedLevel = btn; 
    }


    public void reseter()
    {
        if(Time.timeScale == 0f)
        {
            transform.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0) ;
          btnPause.enabled = true ;
            btnLeft.enabled = true ;
            btnPause.enabled = true ;
            //btnRestart.gameObject.SetActive(true);
            btnSkipLvl.gameObject.SetActive(false);
            txtWin.gameObject.SetActive(false);
            txtLose.gameObject.SetActive(false);
            btnBack.gameObject.SetActive(false);
            img.gameObject.SetActive(false);

        }
        Time.timeScale = 1f;
        death = false ;
    }
    public void Start()
    {
        //playedLevels = 0; 
        //PlayerPrefs.DeleteAll();
        //trans.transform.position = new Vector3(3.5f,-3.5f,0);
        trans.SetActive(true);
        if(!PlayerPrefs.HasKey("currLevel"))
        PlayerPrefs.SetInt("currLevel",currLevel);
        else
        {
            currLevel = PlayerPrefs.GetInt("currLevel",currLevel);
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Time.timeScale == 0f && death)transform.GetComponent<SpriteRenderer>().sprite = deathsprite;
        else{
            if(transform.GetComponent<Rigidbody2D>().velocity.magnitude >= 3.5f)
        {
            transform.GetComponent<SpriteRenderer>().sprite = movesprite;
        }
        else
            transform.GetComponent<SpriteRenderer>().sprite = idlesprite;
            }
    }
}
