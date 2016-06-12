using UnityEngine;
using System.Collections;

public class WinScript : MonoBehaviour {

    const int buttonWidth = 240;
    const int buttonHeight = 120;

    void OnGUI()
    {
        if (
              GUI.Button(
            // Center in X, 2/3 of the height in Y
                new Rect(
                  Screen.width / 2 - (buttonWidth / 2),
                  (2 * Screen.height / 3) - (buttonHeight / 2),
                  buttonWidth,
                  buttonHeight
                ),
                "Back to menu"
              )
            )
        {
            // Reload the level
            Application.LoadLevel("Menu");
        }
    }
}
