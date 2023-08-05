using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class King : Figure
{
    public King(int id, figureColorEnum figureColor, GameObject figurePicture, int x, int y) : 
    base(id, figureColor, Figure.figureTypeEnum.king, figurePicture, x, y){
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     public List<int[]> AllowedMoves(){
        List<int[]> res = new List<int[]>();

        Figure.figureColorEnum myColor;

        if (Landscape.humanTurn){
            myColor = Figure.figureColorEnum.white;
        }else{
            myColor = Figure.figureColorEnum.black;
        }

        if (y + 1 < 8){
            if (!((null != Landscape.tile_grid[x, y + 1]) && (myColor == Landscape.tile_grid[x, y + 1].figureColor))){
                int[] el = new int[2];
                el[0] = x;
                el[1] = y + 1;
                res.Add(el);
            }
        }

        if ((x - 1 >= 0) && (y + 1 < 8)){
            if (!((null != Landscape.tile_grid[x - 1, y + 1]) && (myColor == Landscape.tile_grid[x - 1, y + 1].figureColor))){
                int[] el = new int[2];
                el[0] = x - 1;
                el[1] = y + 1;
                res.Add(el);
            }
        }

         if ((x + 1 < 8) && (y + 1 < 8)){
            if (!((null != Landscape.tile_grid[x + 1, y + 1]) && (myColor == Landscape.tile_grid[x + 1, y + 1].figureColor))){
                int[] el = new int[2];
                el[0] = x + 1;
                el[1] = y + 1;
                res.Add(el);
            }
        }

        if (x - 1 >= 0){
            if (!((null != Landscape.tile_grid[x - 1, y]) && (myColor == Landscape.tile_grid[x - 1, y].figureColor))){
                int[] el = new int[2];
                el[0] = x - 1;
                el[1] = y;
                res.Add(el);
            }
        }

        if (x + 1 < 8){
            if (!((null != Landscape.tile_grid[x + 1, y]) && (myColor == Landscape.tile_grid[x + 1, y].figureColor))){
                int[] el = new int[2];
                el[0] = x + 1;
                el[1] = y;
                res.Add(el);
            }
        }

        if (y - 1 >= 0){
            if (!((null != Landscape.tile_grid[x, y - 1]) && (myColor == Landscape.tile_grid[x, y - 1].figureColor))){
                int[] el = new int[2];
                el[0] = x;
                el[1] = y - 1;
                res.Add(el);
            }
        }

        if ((x - 1 >= 0) && (y - 1 >= 0)){
            if (!((null != Landscape.tile_grid[x - 1, y - 1]) && (myColor == Landscape.tile_grid[x - 1, y - 1].figureColor))){
                int[] el = new int[2];
                el[0] = x - 1;
                el[1] = y - 1;
                res.Add(el);
            }
        }

         if ((x + 1 < 8) && (y - 1 >= 0)){
            if (!((null != Landscape.tile_grid[x + 1, y - 1]) && (myColor == Landscape.tile_grid[x + 1, y - 1].figureColor))){
                int[] el = new int[2];
                el[0] = x + 1;
                el[1] = y - 1;
                res.Add(el);
            }
        }
        
        return res; 
    }

    public override void Move(int x_new, int y_new){
        
        int[] move = new int[2];
        move[0] = x_new;
        move[1] = y_new;

        if (AllowedMoves().Any(p => p.SequenceEqual(move))){
            base.Move(x_new, y_new); 
        }
    }
}