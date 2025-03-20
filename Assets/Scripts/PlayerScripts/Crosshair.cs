using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    //[SerializeField] Sprite crosshairSprite;

    public Texture2D crosshair;
    public Texture2D crosshairUpdate;
    private Vector2 cursorHotspot;

    private void Start()
    {
        SetImg();
        SetSize();
    }
    void SetImg()
    {
        cursorHotspot = new Vector2(crosshair.width / 2, crosshair.height / 2);// so its set in centre of cursor object
        //if we want like strtegy game cursor than its just w
        Cursor.SetCursor(crosshair, cursorHotspot, CursorMode.ForceSoftware);
    }
    void SetSize()
    {// WORKS FOR HTML ONLY MUST FIX FOR PC
        crosshair.width = crosshair.width/2;
        crosshair.height = crosshair.height/2;
        
    }
}
