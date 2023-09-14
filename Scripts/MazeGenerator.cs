using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MazeGenerator : MonoBehaviour
{


    [SerializeField]
    public TextAsset textAssetNames;
    [SerializeField]
    public string[] names;
    public Tilemap tilemap;

    //public Tilemap obstacleTilemap;
    public Tile tilePrefab;
    public Tile tilePrefab2;
    public Tile tilePrefab3;
    public Tile tilePrefab4;
    public Tile tilePrefab5;

    public Tile tiles;
    public Tile obstacleTile;


    public Sprite obstacleSprite;

    public GameObject parentTransform;
    public GameObject player;
    public GameObject finishLine;
    
    /*public Tile tileLeft;
     public Tile tileRight;
      public Tile tileBot;
       public Tile tileTop;
        public Tile tileTopLeft;
         public Tile tileTopRight;
          public Tile tileBotLeft;
           public Tile tileBotRight;
            public Tile tileTopBot;
             public Tile tileLeftRight;*/
    public Vector2 mapSize ;

    public GameObject maze ;

    public Camera cam; 
    public float rotateSpeed = 5f;
    float localSpeed;
    public bool rotRight = false;
    public bool rotLeft = false ;

    public int lastLevel = 1;
    //[Range(0,1)]
    //public float outlinePercent;

    public void leftRotate(bool _rot)
    {
        rotLeft = _rot;
    }

    public void rightRotate(bool _rot)
    {
        rotRight = _rot;
        
    }

    public void resetSpeed()
    {
        localSpeed = rotateSpeed;
    }

    public void btn()
    {
        ReadTextAsset();
        //GenerateMaze();
    }
    public void ReadTextAsset()
    {
        names = textAssetNames.text.Split(new string[] {"\n"}, System.StringSplitOptions.None);
        //Debug.Log(names[9][0]);
    }


    public void nextMaze()
    {
        
        ///lastLevel++;
        //string currPage = "btnLvl"+lastLevel.ToString();
        ///Debug.Log(GameObject.Find("btnLvl2").GetComponent<Button>().GetComponent<Text>().text);
        ///player.gameObject.GetComponent<PlayerInit>().selectedLevel = GameObject.Find(currPage).GetComponent<Button>();
        ///GenerateMaze(lastLevel);
    }
    
    public void GenerateMaze(int nr)
    {
        if(nr != 0) lastLevel = nr ;
        
        rotLeft = false ;
        rotRight = false ;
        
        GameObject.Find("BG").GetComponent<ChangeBG>().changeBG((lastLevel-1)/10+1);
        if((lastLevel-1)/10 == 0)tiles = tilePrefab;
        if((lastLevel-1)/10 == 1)tiles = tilePrefab2;
        if((lastLevel-1)/10 == 2)tiles = tilePrefab3;
        if((lastLevel-1)/10 == 3)tiles = tilePrefab4;
        if((lastLevel-1)/10 >= 4)tiles = tilePrefab5;
        else

        ReadTextAsset();
        int i = 0;
        for( i = 0 ; i < names.Length; i++)if(names[i][0] == '<' && names[i][1] == lastLevel/10+48 && names[i][2] == lastLevel%10+48){
            mapSize.x  = int.Parse(names[i+1]);
            mapSize.y = int.Parse(names[i+2]);
            break;
        }
        
        
        
        tilemap.ClearAllTiles();
//        obstacleTilemap.ClearAllTiles();

        cam.orthographicSize = Mathf.Max(mapSize.x,mapSize.y)/2*1.4f;

        int xOffset =  (int)Mathf.FloorToInt(mapSize.x/2f);
        int yOffset = (int)Mathf.FloorToInt(mapSize.y/2f);

        player.SetActive(true);

        player.GetComponent<Rigidbody2D>().gravityScale = Mathf.Sqrt(mapSize.x * mapSize.y)/10;

        rotateSpeed = 40 - Mathf.Sqrt(mapSize.x * mapSize.y)*0.9f;
        for(int x =  0; x < mapSize.x ; x++)
         for(int y = 0 ; y < mapSize.y ; y++)
            {
               // Debug.Log(x.ToString() + "    "+ y.ToString());
               // Debug.Log(y);
                if(names[(i+3+x)][y] == '1')
                {
                    Vector3Int tilePosition = new Vector3Int(x-xOffset,y-yOffset,0);

                    
                        tilemap.SetTile(tilePosition,tiles);
                }
                else if(names[(i+3+x)][y] == '2')
                {
                   // Debug.Log("--");
                   // Debug.Log(xOffset);
                   // Debug.Log(yOffset);
                    Vector3 tilePosition = new Vector3(y-yOffset+0.5f,xOffset-x-0.5f,0);
                    //finishTilemap.SetTile(tilePosition,finishTilePref);
                    finishLine.SetActive(true);
                    finishLine.gameObject.transform.position = tilePosition;
                }
                else if(names[(i+3+x)][y] == '3')
                {
                    Vector3 tilePosition = new Vector3(y-yOffset+0.5f,xOffset-x-0.5f,0);
                    player.gameObject.transform.position = tilePosition;
                    player.gameObject.transform.rotation = Quaternion.Euler(0,0,0);
                }
                else if(names[(i+3+x)][y] == '4')
                {
                    //Vector3Int tilePosition = new Vector3Int(x-xOffset,y-yOffset,0);
                    //obstacleTilemap.SetTile(tilePosition,obstacleTile);
                    Vector3 tilePosition = new Vector3(y-yOffset+0.5f,xOffset-x-0.5f,-5);
                    GameObject newObstacle = new GameObject();
                    newObstacle.name = "Obstacle";
                    newObstacle.AddComponent<SpriteRenderer>();
                    newObstacle.GetComponent<SpriteRenderer>().sprite = obstacleSprite;
                    newObstacle.transform.position = tilePosition;
                    newObstacle.transform.parent = parentTransform.transform;
                    newObstacle.AddComponent<Rigidbody2D>();
                    newObstacle.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                    newObstacle.AddComponent<CircleCollider2D>();
                    newObstacle.GetComponent<CircleCollider2D>().radius = 0.25f;
                    newObstacle.GetComponent<CircleCollider2D>().isTrigger = true ;
                    newObstacle.AddComponent<Rotater>();
                }
            }
    }


    public void reset()
    {
        
        tilemap.ClearAllTiles();
        foreach(Transform child in parentTransform.transform)
        {
                if(child.gameObject.name == "Obstacle")Destroy(child.gameObject);
        }
        maze.transform.rotation = Quaternion.Euler(0,0,-90);
    }

    // Start is called before the first frame update
    public void Start()
    {
        
        localSpeed = rotateSpeed;
        ReadTextAsset();
        //GenerateMaze();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rotLeft == false && rotRight == false)localSpeed = rotateSpeed;
          if(rotLeft == true )
            {
                if(localSpeed < 2 * rotateSpeed)
                localSpeed =localSpeed + Time.deltaTime * 15 ;
                maze.transform.Rotate(Vector3.back, -localSpeed * Time.deltaTime );
            }
          if(rotRight == true)
            {
                if(localSpeed < 2 * rotateSpeed)
                localSpeed = localSpeed + Time.deltaTime * 15 ;
                maze.transform.Rotate(Vector3.back, localSpeed * Time.deltaTime);
            }  
     }
    
}
