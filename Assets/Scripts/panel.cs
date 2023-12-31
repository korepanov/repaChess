using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using Unity.Collections;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public static bool PanelEnabled = false;
    private static float x = 0;
    private static float y = 0;
    public GameObject PanelUI;
    public const float buttonWidth = 3;
    public const float buttonHeight = 0.5f;  

    public struct Pos{
        public float x; 
        public float y;
    }

    // Start is called before the first frame update
    void Start()
    {
        PanelUI.transform.localPosition = new Vector3(x, y, 0);
        var getCanvasGroup  = PanelUI.GetComponent<CanvasGroup>();
        getCanvasGroup.alpha = 0;
    }

    // Update is called once per frame
    public static void SetPos(float x_new, float y_new){
        x = x_new;
        y = y_new; 
    }

    public static Pos GetPos(){
        Pos p = new Pos(); 
        p.x = x;
        p.y = y; 

        return p; 
    }
    
    void Update()
    {
       PanelUI.transform.localPosition = new Vector3(x, y, 0);

        if (Input.GetMouseButtonDown(0)){
            var getCanvasGroup  = PanelUI.GetComponent<CanvasGroup>();
            getCanvasGroup.alpha = 0;
        }
         if (Input.GetMouseButtonDown(1)){
            var getCanvasGroup  = PanelUI.GetComponent<CanvasGroup>();
            getCanvasGroup.alpha = 1;

            SubPanel.SetPos(x + buttonWidth, y); 

            PanelEnabled = true;
        }
    }
}
