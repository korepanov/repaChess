using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Rook : Figure
{
    public Rook(int id, figureColorEnum figureColor, GameObject figurePicture, int x, int y) : 
    base(id, figureColor, Figure.figureTypeEnum.rook, figurePicture, x, y){
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override bool IsShah()
    {
        for (int x_new = 0; x_new < 8; x_new++){
            for (int y_new = 0; y_new < 8; y_new++){
                if (KingInLine(x_new, y_new)){
                    return true;
                }

            }
        }
        return false; 
    }
    public override List<int[]> AllowedMoves(){
        Figure.figureColorEnum myColor = figureColor;
        List<int[]> res = new List<int[]>();
        var oldBoard = Landscape.CopyBoard(Landscape.tile_grid);

        for (int x_new = 0; x_new < 8; x_new++){
            for (int y_new = 0; y_new < 8; y_new++){
                if (inLine(x_new, y_new)){
                    int[] el = new int[2];
                    el[0] = x_new;
                    el[1] = y_new; 

                    int old_x = x;
                    int old_y = y;
                    ShadowMove(el[0], el[1]); 
                    if (!Landscape.IsShah(myColor)){
                        res.Add(el);
                    }
                    x = old_x;
                    y = old_y; 

                    Landscape.tile_grid = Landscape.CopyBoard(oldBoard);
                }

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