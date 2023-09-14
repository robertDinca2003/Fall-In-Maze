using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CallNewLevel : MonoBehaviour
{

    public void nxtLvl()
    {

        GameObject.Find("PauseBtn").GetComponent<newScript>().pressed = false ;
        GameObject.Find("GameMaze").GetComponent<MazeGenerator>().reset();
        int nr = GameObject.Find("GameMaze").GetComponent<MazeGenerator>().lastLevel + 1;
        //Button btn = GameObject.Find("AllBtns").GetComponent<ButtonsUpdate>().allButons[nr-2];
       // ColorBlock cb = btn.colors;
         //       cb.normalColor = Color.green;
          //      cb.highlightedColor = Color.green;
       // GameObject.Find("AllBtns").GetComponent<ButtonsUpdate>().allButons[nr-1].colors = cb;
        
        GameObject.Find("GameMaze").GetComponent<MazeGenerator>().GenerateMaze(nr);
    }
    void Start()
    {
        transform.GetComponent<Button>().onClick.AddListener(nxtLvl);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
