using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public static bool PanelEnabled = false;
    private static float x = 0;
    private static float y = 0;
    public GameObject PanelUI;

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
            PanelEnabled = true;
        }
    }
}
