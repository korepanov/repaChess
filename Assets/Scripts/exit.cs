using UnityEngine;

public class Exit : MonoBehaviour
{
    public void DoExitGame() {
        
        if (Panel.PanelEnabled) {
            Application.Quit();
            Panel.PanelEnabled = false; 
        }
    }   

}
