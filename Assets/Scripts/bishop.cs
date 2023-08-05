using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bishop : Figure
{
    public Bishop(int id, figureColorEnum figureColor, GameObject figurePicture, int x, int y) : 
    base(id, figureColor, Figure.figureTypeEnum.bishop, figurePicture, x, y){
       
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Move(int x_new, int y_new){
        base.Move(x_new, y_new); 
    }
}
