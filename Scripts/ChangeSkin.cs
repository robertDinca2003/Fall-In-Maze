using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSkin : MonoBehaviour
{

    public GameObject newSkin;
    public GameObject actualSkin;

    public GameObject gameSkin;

    public TextAsset skins;
    public int[] canChange = new int[5];

    public int canSkin;
    public void changer()
    {
        canSkin = PlayerPrefs.GetInt("currLevel");
        canSkin = canSkin / 10;
        for(int i = 0 ; i<5 ; i++)if(i <= canSkin)canChange[i] = 1; else canChange[i] = 0 ;
        int nr = newSkin.gameObject.GetComponent<SkinAnim>().getCurrID();
        if(canChange[nr] == 1)
        {
            actualSkin.gameObject.GetComponent<SkinAnim>().UpdateSkin(nr);
            gameSkin.gameObject.GetComponent<PlayerInit>().idlesprite = gameSkin.gameObject.GetComponent<PlayerInit>().allIdleSprite[nr];
            gameSkin.gameObject.GetComponent<PlayerInit>().movesprite = gameSkin.gameObject.GetComponent<PlayerInit>().allMoveSprite[nr];
            gameSkin.gameObject.GetComponent<PlayerInit>().deathsprite = gameSkin.gameObject.GetComponent<PlayerInit>().allDeathSprite[nr];
        }
        
        //Debug.Log(canChange[nr]);
    }
    void Start()
    {
        
        canSkin = PlayerPrefs.GetInt("currLevel");
        canSkin = canSkin / 10;
        canChange = new int[5];
        Debug.Log(canChange.Length);
        
        for(int j = 0 ; j<5 ; j++)if(j <= canSkin)canChange[j] = 1; else canChange[j] = 0 ;
        Debug.Log(canChange[1]);
        Debug.Log(canChange[2]);
        transform.GetComponent<Button>().onClick.AddListener(changer);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(newSkin.GetComponent<SkinAnim>().getCurrID());
        int nr = newSkin.GetComponent<SkinAnim>().getCurrID();
        Debug.Log(canSkin);
        canSkin = PlayerPrefs.GetInt("currLevel");
        canSkin = canSkin / 10;
        for(int j = 0 ; j<5 ; j++)if(j <= canSkin)canChange[j] = 1; else canChange[j] = 0 ;
        if(canChange[nr] == 0)
        {
            transform.GetChild(0).GetComponent<Text>().text =  "Unlock\n in " + (nr*10 - GameObject.Find("AllBtns").GetComponent<ButtonsUpdate>().lvl).ToString()+ " Levels";
            transform.GetComponent<Button>().enabled = false ;
        }
        else
        {
            transform.GetChild(0).GetComponent<Text>().text =  "Select";
            transform.GetComponent<Button>().enabled = true ;
        }
    }
}
