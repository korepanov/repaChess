using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Queen: Figure
{
    public Queen(int id, figureColorEnum figureColor, GameObject figurePicture, int x, int y) : 
    base(id, figureColor, Figure.figureTypeEnum.queen, figurePicture, x, y){
       
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

        for (int x_new = 0; x_new < 8; x_new++){
            for (int y_new = 0; y_new < 8; y_new++){
                if (inLine(x_new, y_new) || inDiag(x_new, y_new)){
                    int[] el = new int[2];
                    el[0] = x_new;
                    el[1] = y_new; 
                    res.Add(el);
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
