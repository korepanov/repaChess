using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class negaMax : MonoBehaviour
{
    private static Figure bestFig; 
    private static int[] bestMove;

    private static int NegaMaxBestMove(Figure[,] board, int depth, Figure.figureColorEnum color){
        int score = -1000;
        
        Figure.figureColorEnum opColor; 

        if (Figure.figureColorEnum.black == color){
            opColor = Figure.figureColorEnum.white;            
        }else{
            opColor = Figure.figureColorEnum.black;
        }

        if (0 == depth){
            return ai.Evaluate(board, color);
        }
        List<Figure> figs = new List<Figure>(); 

        foreach (Figure fig in board){
            if ((null != fig) && (fig.figureColor == color)){
                figs.Add(fig); 
            }
        }

        foreach(Figure fig in figs){
            var moves = fig.AllowedMoves();

            foreach(int[] move in moves){
                var old_board = Landscape.CopyBoard(board);
                int old_x = fig.x;
                int old_y = fig.y; 

                fig.ShadowMove(move[0], move[1]); 
                int tmp = - NegaMaxBestMove(Landscape.tile_grid, depth - 1, opColor);
                Landscape.tile_grid = old_board;
                fig.x = old_x; 
                fig.y = old_y;
                  
                if (tmp > score){
                    bestFig = fig; 
                    bestMove = move; 
                    score = tmp; 
                }
            } 
        }

        return score;
    }

    public static void MakeBestMove(Figure[,] board, int depth, Figure.figureColorEnum color){
        NegaMaxBestMove(board, depth, color); 
        bestFig.Move(bestMove[0], bestMove[1]); 
    }

    void Start()
    {   
        
    }

    

    void Update(){
    
    }

}
