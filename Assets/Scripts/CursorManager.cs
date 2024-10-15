using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorTexture; // Asigna tu textura en el inspector
    private Vector2 hotSpot = new Vector2(0, 0); // Define el punto caliente del cursor

    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, CursorMode.Auto);
    }

    void OnDestroy()
    {
        // Restablece el cursor al predeterminado al destruir el objeto
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}

