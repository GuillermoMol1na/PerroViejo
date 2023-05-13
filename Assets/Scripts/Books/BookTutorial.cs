using UnityEngine;

public class BookTutorial : MonoBehaviour
{
    [SerializeField] private Texture2D cursorTexture;
    private Vector2 cursorHotSpot;
    private Music_Manager mm;
    void Start()
    {
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
        mm.Play("Track10-Librero",false);
        
        cursorHotSpot= new Vector2(cursorTexture.width / 2, cursorTexture.height /2);
        Cursor.SetCursor(cursorTexture, cursorHotSpot, CursorMode.Auto);
    }
    
}
