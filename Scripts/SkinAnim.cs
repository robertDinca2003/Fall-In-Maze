using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinAnim : MonoBehaviour
{
    int currID = 0;

    int lastID = 0 ;
     //int idIdle = 0;

     //int idMove = 0;

     //int idDeath = 0;

     bool anim = false ;
    public Sprite currIdleSkin;
    public Sprite currMoveSkin;

    public Sprite currDeathSkin;

    public Sprite[] IdleSkin= new Sprite[5];

    public Sprite[] MoveSkin= new Sprite[5];
    public Sprite[] DeathSkin= new Sprite[5];


    public int getCurrID()
    {
        return currID;
    }
    public void UpdateSkin(int id)
    {
        lastID = currID ; 
        Debug.Log(id);
        
        //if()
        currIdleSkin =  IdleSkin[id];
        currMoveSkin =  MoveSkin[id];
        currDeathSkin = DeathSkin[id];
    }
    public void ChangeSkin(int nr)
    {
        if(currID == 0 && nr == -1)currID = IdleSkin.Length-1;
        else if(currID == IdleSkin.Length-1 && nr == 1 ) currID = 0 ;
        else currID += nr;
        currIdleSkin =  IdleSkin[currID];
        currMoveSkin =  MoveSkin[currID];
        currDeathSkin = DeathSkin[currID];
    }

    public void Start()
    {
        currID = lastID;
//        Debug.Log(lastID);
        currIdleSkin =  IdleSkin[lastID];
        currMoveSkin =  MoveSkin[lastID];
        currDeathSkin = DeathSkin[lastID];
    }

    public void holding(bool ok)
    {
        anim = ok ;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(anim == true)
        {
            transform.GetComponent<Image>().sprite = currMoveSkin ;
             
        }
        else if(anim == false)
        {
            transform.GetComponent<Image>().sprite = currIdleSkin ;
            
        }
    }
}
