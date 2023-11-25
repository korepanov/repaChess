using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public class NegaMax : MonoBehaviour
{
    private static Figure bestFig; 
    private static int[] bestMove;
    
    private static int NegaMaxBestMove(int depth, Figure.figureColorEnum color){
        int score = -1000;
        var random = new System.Random();
        
        List<Figure> figs = new List<Figure>(); 

        foreach (Figure fig in Landscape.tile_grid){
            if ((null != fig) && (fig.figureColor == color)){
                figs.Add(fig); 
            }
        }
        
        var num = random.Next(0, figs.Count);
        Figure bestFigLocal = figs[num]; 
        var movesForFig = figs[num].AllowedMoves();
        while (movesForFig.Count == 0){
            num = random.Next(0, figs.Count);
            bestFigLocal = figs[num]; 
            movesForFig = figs[num].AllowedMoves();
        }
       
        int[] bestMoveLocal = movesForFig[random.Next(0, movesForFig.Count)];

        Figure.figureColorEnum opColor; 

        if (Figure.figureColorEnum.black == color){
            opColor = Figure.figureColorEnum.white;            
        }else{
            opColor = Figure.figureColorEnum.black;
        }

        if (0 == depth){
            bestFig = bestFigLocal;
            bestMove = bestMoveLocal;

            return ai.Evaluate(Landscape.tile_grid, color);
        }

        foreach(Figure fig in figs){
            var moves = fig.AllowedMoves();

            foreach(int[] move in moves){
                var old_board = Landscape.CopyBoard(Landscape.tile_grid);
                int old_x = fig.x;
                int old_y = fig.y; 

                fig.ShadowMove(move[0], move[1]);
                Landscape.debugBoard(); 
                
                int tmp = - NegaMaxBestMove(depth - 1, opColor);
                
                Landscape.tile_grid = Landscape.CopyBoard(old_board);
                fig.x = old_x; 
                fig.y = old_y;
                  
                if (tmp > score){
                    bestFigLocal = fig; 
                    bestMoveLocal = move; 
                    score = tmp; 
                }
            } 
        }

        bestFig = bestFigLocal;
        bestMove = bestMoveLocal;

        return score;
    }
   
    public static void MakeBestMove(int depth, Figure.figureColorEnum color){
        NegaMaxBestMove(depth, color); 
        Debug.Log(bestFig.x.ToString() + "; " + bestFig.y.ToString() + " -> " + bestMove[0].ToString() + "; " + bestMove[1].ToString());
        bestFig.Move(bestMove[0], bestMove[1]); 
    }

    void Start()
    {   
       
    }


    void Update(){
    
    }

}
