using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ai
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static int Evaluate(Figure[,] board, Figure.figureColorEnum color){
        int white_weight = 0;
        int black_weight = 0;
        int weight = 0;  

        foreach(Figure fig in board){
            if (null != fig){
                if (Figure.figureTypeEnum.pawn == fig.figureType){
                    weight = 1;
                }
                if (Figure.figureTypeEnum.knight == fig.figureType){
                    weight = 3;
                }
                if (Figure.figureTypeEnum.bishop == fig.figureType){
                    weight = 3;
                }
                if (Figure.figureTypeEnum.rook == fig.figureType){
                    weight = 5;
                }
                if (Figure.figureTypeEnum.queen == fig.figureType){
                    weight = 9;
                }
                if (Figure.figureTypeEnum.king == fig.figureType){
                    weight = 1000;
                }
                if (Figure.figureColorEnum.white == fig.figureColor){
                    white_weight += weight;
                }else{
                    black_weight += weight;
                }
            }
        }

        if (Figure.figureColorEnum.white == color){
            return white_weight - black_weight;
        }
        return black_weight - white_weight; 
    }


    public static int RandomMove(Figure.figureColorEnum myColor){
        var rand = new System.Random();

        List<Figure> figs = new List<Figure>(); 

        foreach (Figure fig in Landscape.tile_grid){
            if ((null != fig) && (fig.figureColor == Figure.figureColorEnum.black)){
                figs.Add(fig); 
            }
        }

        
        int figNum = rand.Next(figs.Count);
        
        var moves = figs[figNum].AllowedMoves();

        while (0 == moves.Count){
            figNum = rand.Next(figs.Count);
            moves = figs[figNum].AllowedMoves();
        } 

        var movNum = rand.Next(moves.Count); 
        
        figs[figNum].Move(moves[movNum][0], moves[movNum][1]);
        
        return 0;  
    }

    public void Move(){   
        negaMax.MakeBestMove(Landscape.tile_grid, 3, Figure.figureColorEnum.black); 
        Landscape.humanTurn = true;
    }
}
