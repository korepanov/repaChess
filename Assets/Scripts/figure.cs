using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public abstract class Figure
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

    public abstract List<int[]> AllowedMoves();
    
    // does figure make shah now 
    public abstract bool IsShah();

    public virtual void Move(int x_new, int y_new){
        if ((null != Landscape.tile_grid[x, y]) && (x_new >= 0) && (x_new < 8) && (y_new >=0) && (y_new < 8)){
            if (null != Landscape.tile_grid[x_new, y_new]){
                Landscape.Destroy(GameObject.Find(Landscape.tile_grid[x_new, y_new].id.ToString())); 
            }
            var id = Landscape.tile_grid[x,y].id;
            Landscape.Destroy(GameObject.Find(Landscape.tile_grid[x, y].id.ToString())); 
            Landscape.CreateTile(id, x_new, y_new); 
            
            Landscape.tile_grid[x_new, y_new] = Landscape.tile_grid[x, y];
            Landscape.tile_grid[x, y] = null; 
            Landscape.tile_grid[x_new, y_new].x = x_new;
            Landscape.tile_grid[x_new, y_new].y = y_new;
            
            x = x_new;
            y = y_new; 
            
            Landscape.humanTurn = !Landscape.humanTurn;
        }
    }

    public void ShadowMove(int x_new, int y_new){
        if ((null != Landscape.tile_grid[x, y]) && (x_new >= 0) && (x_new < 8) && (y_new >=0) && (y_new < 8)){   
            Landscape.tile_grid[x_new, y_new] = Landscape.tile_grid[x, y];
            Landscape.tile_grid[x, y] = null; 
            
            Landscape.tile_grid[x_new, y_new].x = x_new;
            Landscape.tile_grid[x_new, y_new].y = y_new;
            x = x_new;
            y = y_new; 
        }
    }


    protected bool inLine(int x_new, int y_new){
        
        Figure.figureColorEnum myColor = figureColor;

        if ((x == x_new) && (y == y_new)){
            return false;
        }

        int x_temp = x;
        int y_temp = y; 

        if (x_temp == x_new){
            if (y_new > y_temp){
                while (y_temp != y_new){
                    y_temp++;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }else{
                 while (y_temp != y_new){
                    y_temp--;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }
        }
        if (y_temp == y_new){
            if (x_new > x_temp){
                while (x_temp != x_new){
                    x_temp++;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }else{
               while (x_temp != x_new){
                    x_temp--;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }
        }

        return false; 
    }
    protected bool inDiag(int x_new, int y_new){

        Figure.figureColorEnum myColor = figureColor;
        
        if ((x == x_new) && (y == y_new)){
            return false;
        }

        int x_temp = x;
        int y_temp = y;

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }

            x_temp--;
            y_temp++;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        x_temp = x;
        y_temp = y; 

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }
            
            x_temp++;
            y_temp--;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        x_temp = x;
        y_temp = y;

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }
            
            x_temp--;
            y_temp--;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        x_temp = x;
        y_temp = y; 

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null == Landscape.tile_grid[x_new, y_new] || (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType != figureTypeEnum.king));
            }
            
            x_temp++;
            y_temp++;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        return false; 

    }


    protected bool KingInLine(int x_new, int y_new){
        
        Figure.figureColorEnum myColor = figureColor;

        if ((x == x_new) && (y == y_new)){
            return false;
        }

        int x_temp = x;
        int y_temp = y; 

        if (x_temp == x_new){
            if (y_new > y_temp){
                while (y_temp != y_new){
                    y_temp++;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }else{
                 while (y_temp != y_new){
                    y_temp--;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }
        }
        if (y_temp == y_new){
            if (x_new > x_temp){
                while (x_temp != x_new){
                    x_temp++;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }else{
               while (x_temp != x_new){
                    x_temp--;
                    if (null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                        return false;
                    }
                }
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }
        }

        return false; 
    }
    protected bool KingInDiag(int x_new, int y_new){

        Figure.figureColorEnum myColor = figureColor;
        
        if ((x == x_new) && (y == y_new)){
            return false;
        }

        int x_temp = x;
        int y_temp = y;

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }

            x_temp--;
            y_temp++;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        x_temp = x;
        y_temp = y; 

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }
            
            x_temp++;
            y_temp--;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        x_temp = x;
        y_temp = y;

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }
            
            x_temp--;
            y_temp--;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        x_temp = x;
        y_temp = y; 

        while (x_temp >=0 && x_temp < 8 && y_temp >= 0 && y_temp < 8){
            if (x_temp == x_new && y_temp == y_new){
                return (null != Landscape.tile_grid[x_new, y_new] && (myColor != Landscape.tile_grid[x_new, y_new].figureColor && Landscape.tile_grid[x_new, y_new].figureType == figureTypeEnum.king));
            }
            
            x_temp++;
            y_temp++;

            if (x_temp >= 0 && x_temp < 8 && y_temp >= 0 && y_temp < 8 && null != Landscape.tile_grid[x_temp, y_temp] && (x_temp != x_new || y_temp != y_new)){
                break;
            }
        }

        return false; 

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
