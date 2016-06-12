using UnityEngine;
using System.Collections;

public class MenuScript : MonoBehaviour
{
    void OnGUI()
    {
        const int buttonWidth = 240;
        const int buttonHeight = 120;

        Rect buttonRect = new Rect(
              Screen.width / 2 - (buttonWidth / 2),
              (2 * Screen.height / 3) - (buttonHeight / 2),
              buttonWidth,
              buttonHeight
            );
        
        if (GUI.Button(buttonRect, "Start!"))
        {
            Application.LoadLevel("Level1");
        }
    }
}
