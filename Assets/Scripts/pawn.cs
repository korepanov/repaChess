using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pawn : Figure
{
    public Pawn(int id, figureColorEnum figureColor, GameObject figurePicture, int x, int y) : 
    base(id, figureColor, Figure.figureTypeEnum.pawn, figurePicture, x, y){
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override List<int[]> AllowedMoves(){
        Figure.figureColorEnum myColor = figureColor;

        List<int[]> res = new List<int[]>();

        if ((y + 1 < 8) && (null == Landscape.tile_grid[x, y + 1]) && (myColor == Figure.figureColorEnum.white)){
            int[] el = new int[2];
            el[0] = x;
            el[1] = y + 1;
            res.Add(el);
        }

         if ((y - 1 >= 0) && (null == Landscape.tile_grid[x, y - 1]) && (myColor == Figure.figureColorEnum.black)){
            int[] el = new int[2];
            el[0] = x;
            el[1] = y - 1;
            res.Add(el);
        }

        if ((x - 1 >= 0) && (y + 1 < 8) && (null != Landscape.tile_grid[x - 1, y + 1]) && (myColor == Figure.figureColorEnum.white)){
            if (Landscape.tile_grid[x - 1, y + 1].figureColor != myColor && Landscape.tile_grid[x - 1, y + 1].figureType != figureTypeEnum.king){
                int[] el = new int[2];
                el[0] = x - 1;
                el[1] = y + 1;
                res.Add(el);
            }
        }

         if ((x + 1 < 8) && (y + 1 < 8) && (null != Landscape.tile_grid[x + 1, y + 1]) && (myColor == Figure.figureColorEnum.white)){
            if (Landscape.tile_grid[x + 1, y + 1].figureColor != myColor && Landscape.tile_grid[x + 1, y + 1].figureType != figureTypeEnum.king){
                int[] el = new int[2];
                el[0] = x + 1;
                el[1] = y + 1;
                res.Add(el);
            }
        }

         if ((x - 1 >= 0) && (y - 1 >= 0) && (null != Landscape.tile_grid[x - 1, y - 1]) && (myColor == Figure.figureColorEnum.black)){
            if (Landscape.tile_grid[x - 1, y - 1].figureColor != myColor && Landscape.tile_grid[x - 1, y - 1].figureType != figureTypeEnum.king){
                int[] el = new int[2];
                el[0] = x - 1;
                el[1] = y - 1;
                res.Add(el);
            }
        }

         if ((x + 1 < 8) && (y - 1 >= 0) && (null != Landscape.tile_grid[x + 1, y - 1]) && (myColor == Figure.figureColorEnum.black)){
            if (Landscape.tile_grid[x + 1, y - 1].figureColor != myColor && Landscape.tile_grid[x + 1, y - 1].figureType != figureTypeEnum.king){
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
