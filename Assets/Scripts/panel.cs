using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class Panel : MonoBehaviour
{
    private static float x = 0;
    private static float y = 0;
    public GameObject PanelUI;
    // Start is called before the first frame update
    void Start()
    {
        PanelUI.transform.localPosition = new Vector3(x, y, 0);
        PanelUI.SetActive(false);
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
            PanelUI.SetActive(false);
        }
         if (Input.GetMouseButtonDown(1)){
            PanelUI.SetActive(true);
        }
    }
}
