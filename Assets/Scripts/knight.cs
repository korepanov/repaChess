using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Knight : Figure
{
    public Knight(int id, figureColorEnum figureColor, GameObject figurePicture, int x, int y) : 
    base(id, figureColor, Figure.figureTypeEnum.knight, figurePicture, x, y){
       
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

        int x_new;
        int y_new; 

        if ((x - 1 >= 0) && (y - 2 >= 0)){
            x_new = x - 1;
            y_new = y - 2;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
                res.Add(el);
            }
        }

        if ((x - 1 >= 0) && (y + 2 < 8)){
            x_new = x - 1;
            y_new = y + 2;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
                res.Add(el);
            }
        }

        if ((x - 2 >= 0) && (y - 1 >= 0)){
            x_new = x - 2;
            y_new = y - 1;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
                res.Add(el);
            }
        }

        if ((x - 2 >= 0) && (y + 1 < 8)){
            x_new = x - 2;
            y_new = y + 1;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
                res.Add(el);
            }
        }

        if ((x + 1 < 8) && (y - 2 >= 0)){
            x_new = x + 1;
            y_new = y - 2;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
                res.Add(el);
            }
        }

        if ((x + 1 < 8) && (y + 2 < 8)){
            x_new = x + 1;
            y_new = y + 2;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
                res.Add(el);
            }
        }

        if ((x + 2 < 8) && (y - 1 >= 0)){
            x_new = x + 2;
            y_new = y - 1;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
                res.Add(el);
            }
        }

        if ((x + 2 < 8) && (y + 1 < 8)){
            x_new = x + 2;
            y_new = y + 1;
            if (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king)){
                int[] el = new int[2];
                el[0] = x_new;
                el[1] = y_new;
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
