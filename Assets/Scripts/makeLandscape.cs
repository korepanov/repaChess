using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

 

public class Landscape : MonoBehaviour
{
    public static bool humanTurn = true;
    [SerializeField] Camera mainCamera;
    public static Dictionary<int, Figure> tileset;
    Dictionary<int, GameObject> tile_groups;
    public static GameObject black_square;
    public static GameObject white_square;
    public static float scale = 1.28f;
    private ai computer = new ai();
    public static Figure[,] tile_grid = new Figure[8,8];
 
    int selected_x = -1;
    int selected_y = -1; 

    void Start()
    {   
        CreateTileset();
        CreateTileGroups();
        GenerateMap();
        SetCamera(); 
        InitBoard(); 
    }

    

    void Update(){

        if (Input.GetMouseButtonDown(0)){
            Vector3 pos = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mainCamera.transform.position.z * (-1)));
            pos.x /= scale;
            pos.y /= scale;
            int x = (int)(pos.x + 0.5);
            int y = (int)(pos.y + 0.5);

            if ((selected_x >= 0) && (selected_y >= 0) && (Figure.figureColorEnum.white == tile_grid[selected_x, selected_y].figureColor) && humanTurn){
                tile_grid[selected_x, selected_y].Move(x, y);
                selected_x = -1;
                selected_y = -1; 
            } else if ((x >= 0) && (y >= 0) && (x < 8) && (y < 8) && (null != tile_grid[x, y])){
                selected_x = x;
                selected_y = y;
            }
            
        }

        if (!humanTurn && !Input.GetMouseButtonDown(0)){
            computer.Move();
        }

    }
 
    void CreateTileset()
    {
        white_square = Instantiate(GameObject.Find("white_square"));
        black_square = Instantiate(GameObject.Find("black_square"));
        tileset = new Dictionary<int, Figure>();
       
        for (int x = 0; x < 8; x++){
            GameObject white_pawn = Instantiate(GameObject.Find("white_pawn"));
            Pawn pawn = new Pawn(x + 2, Figure.figureColorEnum.white, white_pawn, x, 1);
            tileset.Add(x + 2, pawn);
        }

        for (int x = 0; x < 8; x++){
            GameObject black_pawn = Instantiate(GameObject.Find("black_pawn"));
            Pawn pawn = new Pawn(x + 10, Figure.figureColorEnum.black, black_pawn, x, 6);
            tileset.Add(x + 10, pawn);
        }

        GameObject white_king_picture = Instantiate(GameObject.Find("white_king"));
        King white_king = new King(18, Figure.figureColorEnum.white, white_king_picture, 4, 0);
        tileset.Add(18, white_king);

        GameObject black_king_picture = Instantiate(GameObject.Find("black_king"));
        King black_king = new King(19, Figure.figureColorEnum.black, black_king_picture, 4, 7);
        tileset.Add(19, black_king);

        GameObject white_queen_picture = Instantiate(GameObject.Find("white_queen"));
        Queen white_queen = new Queen(20, Figure.figureColorEnum.white, white_queen_picture, 3, 0);
        tileset.Add(20, white_queen);

        GameObject black_queen_picture = Instantiate(GameObject.Find("black_queen"));
        Queen black_queen = new Queen(21, Figure.figureColorEnum.black, black_queen_picture, 3, 7);
        tileset.Add(21, black_queen);

        GameObject white_rook_picture = Instantiate(GameObject.Find("white_rook"));
        Rook white_rook = new Rook(22, Figure.figureColorEnum.white, white_rook_picture, 0, 0);
        tileset.Add(22, white_rook);

        GameObject white_rook_picture2 = Instantiate(GameObject.Find("white_rook"));
        Rook white_rook2 = new Rook(23, Figure.figureColorEnum.white, white_rook_picture2, 7, 0);
        tileset.Add(23, white_rook2);

        GameObject black_rook_picture = Instantiate(GameObject.Find("black_rook"));
        Rook black_rook = new Rook(24, Figure.figureColorEnum.black, black_rook_picture, 0, 7);
        tileset.Add(24, black_rook);

        GameObject black_rook_picture2 = Instantiate(GameObject.Find("black_rook"));
        Rook black_rook2 = new Rook(25, Figure.figureColorEnum.black, black_rook_picture2, 7, 7);
        tileset.Add(25, black_rook2);

        GameObject white_knight_picture = Instantiate(GameObject.Find("white_knight"));
        Knight white_knight = new Knight(26, Figure.figureColorEnum.white, white_knight_picture, 1, 0);
        tileset.Add(26, white_knight);

        GameObject white_knight_picture2 = Instantiate(GameObject.Find("white_knight"));
        Knight white_knight2 = new Knight(27, Figure.figureColorEnum.white, white_knight_picture2, 6, 0);
        tileset.Add(27, white_knight2);

        GameObject black_knight_picture = Instantiate(GameObject.Find("black_knight"));
        Knight black_knight = new Knight(28, Figure.figureColorEnum.black, black_knight_picture, 1, 7);
        tileset.Add(28, black_knight);

        GameObject black_knight_picture2 = Instantiate(GameObject.Find("black_knight"));
        Knight black_knight2 = new Knight(29, Figure.figureColorEnum.black, black_knight_picture2, 6, 7);
        tileset.Add(29, black_knight2);

        GameObject white_bishop_picture = Instantiate(GameObject.Find("white_bishop"));
        Bishop white_bishop = new Bishop(30, Figure.figureColorEnum.white, white_bishop_picture, 2, 0);
        tileset.Add(30, white_bishop);

        GameObject white_bishop_picture2 = Instantiate(GameObject.Find("white_bishop"));
        Bishop white_bishop2 = new Bishop(31, Figure.figureColorEnum.white, white_bishop_picture2, 5, 0);
        tileset.Add(31, white_bishop2);

        GameObject black_bishop_picture = Instantiate(GameObject.Find("black_bishop"));
        Bishop black_bishop = new Bishop(32, Figure.figureColorEnum.black, black_bishop_picture, 2, 7);
        tileset.Add(32, black_bishop);

        GameObject black_bishop_picture2 = Instantiate(GameObject.Find("black_bishop"));
        Bishop black_bishop2 = new Bishop(33, Figure.figureColorEnum.black, black_bishop_picture2, 5, 7);
        tileset.Add(33, black_bishop2);
        
    }
 
    void CreateTileGroups()
    {
 
        tile_groups = new Dictionary<int, GameObject>();
        foreach(KeyValuePair<int, Figure> prefab_pair in tileset)
        {
            GameObject tile_group = new GameObject(prefab_pair.Value.figurePicture.name);
            tile_group.transform.parent = gameObject.transform;
            tile_group.transform.localPosition = new Vector3(0, 0, 0);
            tile_groups.Add(prefab_pair.Key, tile_group);
        }
    }
    
    void SetCamera(){
        mainCamera.transform.position = new Vector3(3.5f*scale, 3.5f*scale, -400);
    }

    void GenerateMap()
    {
        int tile_id = 0;
        bool was_here = false;

        for(int x = 0; x < 8; x+=1)
        {
 
            for(int y = 0; y < 8; y+=1)
            {
                CreateTile(tile_id, x, y);
                
                if (!was_here){
                    tile_id++;
                    was_here = true;
                }else{
                    tile_id--;
                    was_here = false;
                }
            }

            if (!was_here){
                tile_id++;
                was_here = true;
            }else{
                tile_id--;
                was_here = false;
            }
        }
	
    }
 
    void InitBoard(){
        for (int x = 2; x < 34; x++){
            CreateTile(x, tileset[x].x, tileset[x].y); 
        }
    }
    
    public static void CreateTile(int tile_id, int x, int y)
    {
        GameObject tile_prefab;
        GameObject tile; 
        
        if (0 == tile_id){
            tile_prefab = black_square;
        }else if (1 == tile_id){
            tile_prefab = white_square;
        }else{
            tile_prefab = tileset[tile_id].figurePicture;
        }
        
        tile = Instantiate(tile_prefab);
        tile.name = string.Format(tile_id.ToString(), x, y);
        tile.transform.localPosition = new Vector3(x*scale, y*scale, 0);
        if (tile_id > 1){
            tile_grid[x, y] = tileset[tile_id];
        }
    }

}


    
