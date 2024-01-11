using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubPanel : MonoBehaviour
{
    public static bool PanelEnabled = false;
    public static bool WasClick = false; 
    private static float x = 0;
    private static float y = 0;
    public GameObject SubPanelUI;
    public const float height = 1f;

    public struct Pos{
        public float x; 
        public float y;
    }

    // Start is called before the first frame update
    void Start()
    {
        SubPanelUI.transform.localPosition = new Vector3(x, y, 0);
        var getCanvasGroup  = SubPanelUI.GetComponent<CanvasGroup>();
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
       SubPanelUI.transform.localPosition = new Vector3(x, y, 0);

        if (Input.GetMouseButtonDown(0)){
            PanelEnabled = false;
        }

        if (PanelEnabled){
            var getCanvasGroup  = SubPanelUI.GetComponent<CanvasGroup>();
            getCanvasGroup.alpha = 1;
            PanelEnabled = true;
        }else{
            var getCanvasGroup  = SubPanelUI.GetComponent<CanvasGroup>();
            getCanvasGroup.alpha = 0;
        }
    }

    public void WasPanelClick(){
        if (Input.GetMouseButtonDown(0)){
            WasClick = true;
        }
    }
}
