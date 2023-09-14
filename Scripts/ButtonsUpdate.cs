using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class ButtonsUpdate : MonoBehaviour
{
    public int lvl = 0;

    public GameObject obj ;
    public int allUnlocked = 0 ;
    public Button[] allButons = new Button[50];

    //public TextAsset btnFile;

    public string[] unlockBtn = new string[51];
    // Start is called before the first frame update

    public void unlockLvl(int nr)
    {
        /*
        string path = Application.dataPath + "/TxtFiles/btnFile.txt";

        StreamWriter writer = new StreamWriter(path);
        

        Debug.Log(nr);
        if(unlockBtn[nr][3] == '0')
        {
            allButons[nr].enabled = true ;
            
        }
        //TextAsset newBtnFile = new TextAsset();
        //btnFile.text.Remove(0,50);
        //Debug.Log(btnFile.text.Length);
        string str = "";
        for(int i=0 ; i < 50; i++)
        {
            
            str = str + ((i+1)/10).ToString() + ((i+1)%10).ToString() + ' ';
            //Debug.Log(str);
            //if(allButons[i].enabled == true) 
            if(allButons[i].enabled == true && (allButons[i].GetComponent<Button>().colors.normalColor == Color.green || unlockBtn[i][3] == '2')) str = str + '2';
            else if(allButons[i].enabled == true) str = str + '1' ;
            else if(allButons[i].enabled == false) str = str + '0'; 
            str = str + " -1\n";
            Debug.Log(str);
            Debug.Log('\n');
            
        }
        //if(!File.Exists(path))
        writer.Write(str);
        writer.Close();
                //File.WriteAllText(path,str);
                
                //Resources.Load(path);
        
        //btnFile = newBtnFile;*/
        selectButtons();
    }

    void readFiles()
    {
        string path = Application.dataPath + "/TxtFiles/btnFile.txt";

        StreamReader reader = new StreamReader(path);
        string line = "";
        int i = 0 ;
        while(!reader.EndOfStream)
        {
            //Debug.Log(i);
            line  = reader.ReadLine();
           // Debug.Log(line);
            unlockBtn[i] = line;
            i++;

        }
    }
    public void selectButtons()
    {
        //readFiles();
        //allUnlocked = 0 ;
        
        lvl = PlayerPrefs.GetInt("currLevel"); 
        Debug.Log(lvl);
        for(int i = 0 ; i < 50 ; i++)
        {
            if(i < lvl)
            {
                allButons[i].enabled = true;
                allButons[i].GetComponent<Image>().color = Color.green;
            }
            if(i == lvl)
            {
                allButons[i].enabled = true;
                Color clr;
                 ColorUtility.TryParseHtmlString("F5C100",out clr);
                allButons[i].GetComponent<Image>().color = clr;
            }
            if(i > lvl)
            {
                allButons[i].enabled = false ;
                allButons[i].GetComponent<Image>().color = Color.gray;
            }

        }
        //unlockBtn = btnFile.text.Split(new string[] {"\n"}, System.StringSplitOptions.None);
        /*
        for(int i = 0 ; i < 50  ; i++)
        {
            if(unlockBtn[i][3] == '1') 
            {
                allButons[i].enabled = true;
                Color clr;
                 ColorUtility.TryParseHtmlString("F5C100",out clr);
                allButons[i].GetComponent<Image>().color = clr;

                
            }
            else if(unlockBtn[i][3] == '2')
            {
                allUnlocked++;
                allButons[i].enabled = true;
                allButons[i].GetComponent<Image>().color = Color.green;
            }
            else 
            {
                allButons[i].enabled = false ;
                allButons[i].GetComponent<Image>().color = Color.gray;
            }
        }*/
    }
    void Start()
    {
        readFiles();
        lvl = obj.GetComponent<PlayerInit>().currLevel; 
     //   unlockBtn = btnFile.text.Split(new string[] {"\n"}, System.StringSplitOptions.None);
        GameObject.Find("btnPlay").GetComponent<Button>().onClick.AddListener(selectButtons);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
