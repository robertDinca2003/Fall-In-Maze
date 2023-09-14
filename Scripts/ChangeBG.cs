using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeBG : MonoBehaviour
{

    public Sprite bg1;
    public Sprite bg2;
    public Sprite bg3;
    public Sprite bg4;
    public Sprite bg5;

    public GameObject obj ;

    int lastPage = 0;
    // Start is called before the first frame update

    public void lstPag(int nr)
    {
            lastPage = nr ;
    }
    public void changeBG(int nr)
    {
        if(nr == 1)transform.GetComponent<Image>().sprite = bg1;
        if(nr == 2)transform.GetComponent<Image>().sprite = bg2;
        if(nr == 3)transform.GetComponent<Image>().sprite = bg3;
        if(nr == 4)transform.GetComponent<Image>().sprite = bg4;
        if(nr == 5)transform.GetComponent<Image>().sprite = bg5;
    }
    public void updatePage()
    {
        if(lastPage == 1)transform.GetComponent<Image>().sprite = bg1;
        if(lastPage == 2)transform.GetComponent<Image>().sprite = bg2;
        if(lastPage == 3)transform.GetComponent<Image>().sprite = bg3;
        if(lastPage == 4)transform.GetComponent<Image>().sprite = bg4;
        if(lastPage == 5)transform.GetComponent<Image>().sprite = bg5;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
