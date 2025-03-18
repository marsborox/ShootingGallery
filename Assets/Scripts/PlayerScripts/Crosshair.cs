using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Sprite crosshairSprite;

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
        cursorHotspot = new Vector2(crosshair.width / 2, crosshair.height / 2);
        Cursor.SetCursor(crosshair, cursorHotspot, CursorMode.ForceSoftware);
    }
    void SetSize()
    {
        crosshair.width = crosshair.width * 2;
        crosshair.height = crosshair.height * 2;
    }
}
