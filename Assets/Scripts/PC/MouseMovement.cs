using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseMovement : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private Vector2 cursorHotSpot;
    void Start()
    {
        //cursorHotSpot= new Vector2(cursorTexture.width / 2, cursorTexture.height /2);
        cursorHotSpot= new Vector2(0f, 0f);
        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
    }

}
