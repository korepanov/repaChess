using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Figure
{
    public int id; 
    public GameObject figurePicture;

    public enum figureTypeEnum{
            pawn,
            king,
            queen,
            rook,
            knight,
            bishop, 
    }

    public enum figureColorEnum{
        black,
        white 
    }

    public int x = 0;
    public int y = 0;

    public figureTypeEnum figureType = figureTypeEnum.pawn;
    public figureColorEnum figureColor = figureColorEnum.black;
    
    public Figure(int id, figureColorEnum figureColor, figureTypeEnum figureType, GameObject figurePicture, int x, int y){
        this.id = id; 
        this.figureColor = figureColor;
        this.figureType = figureType;
        this.figurePicture = figurePicture; 
        this.x = x;
        this.y = y;  
    }

    public virtual void Move(int x_new, int y_new){
        if ((null != Landscape.tile_grid[x, y]) && (x_new >= 0) && (x_new < 8) && (y_new >=0) && (y_new < 8)){
            if (null != Landscape.tile_grid[x_new, y_new]){
                Landscape.Destroy(GameObject.Find(Landscape.tile_grid[x_new, y_new].id.ToString())); 
            }
            Landscape.CreateTile(Landscape.tile_grid[x,y].id, x_new, y_new); 
            Landscape.Destroy(GameObject.Find(Landscape.tile_grid[x, y].id.ToString())); 
            Landscape.tile_grid[x_new, y_new] = Landscape.tile_grid[x, y];
            Landscape.tile_grid[x, y] = null; 
            x = x_new;
            y = y_new; 
            Landscape.humanTurn = !Landscape.humanTurn;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
