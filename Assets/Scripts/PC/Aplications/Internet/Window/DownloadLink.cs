using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class DownloadLink
{
    private Sprite[] theSpriteSent;
    private Vector2 linkSize;
    private RectTransform imgtrans;
    public Image imageOfSprite;
    public Button buttonLink;
    private float posX = -30248f;
    private float posY;
    private float lastHeight;
    private float halfHeight;
    private float lastHalf;
    private float maxHeightY=19789f;
    public GameObject createDLinks(GameObject link, int i){

        imgtrans = link.AddComponent<RectTransform>();
        linkSize= theSpriteSent[i].bounds.size*2.5f;
        imgtrans.sizeDelta = linkSize;
        halfHeight= theSpriteSent[i].bounds.size.y * 60f;
        //buttonLink = link.AddComponent<Button>();
        
        //Adding the image
        imageOfSprite = link.AddComponent<Image>();
        imageOfSprite.sprite = theSpriteSent[i];
        return link;
    }
    public void SetSprites(Sprite[] sprites){
        theSpriteSent = sprites;
        posX = -30248f;
    }
    public Vector2 givePosition(int i){
            halfHeight= theSpriteSent[i].bounds.size.y * 60f;
            switch(i){
            case 0:
                posY = maxHeightY-halfHeight;
            break;
            case 6:
                posX=-126.25f;
                posY = -3083f;
            break;
            case 9:
                posX=30397;
                posY = maxHeightY-halfHeight;
            break;
            default:
                posY = lastHeight - (halfHeight+lastHalf+ 500f);
            break;
        }
        lastHeight=posY;
        lastHalf=halfHeight;
        return new Vector2(posX,posY);
    }
    public GameObject PageText(TMP_FontAsset pixelFont){
        GameObject textObject = new GameObject("Page_text");
        TMP_Text pageText = textObject.AddComponent<TextMeshProUGUI>();
        RectTransform transTMP = textObject.GetComponent<RectTransform>();
        transTMP.sizeDelta = new Vector2(783.03f, 854.39f);
        transTMP.pivot=new Vector2(0.5f, 0.5f);
        pageText.font = pixelFont;
        pageText.fontSize= 50f;
        pageText.color = new Color32(0,0,0,255);
        pageText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopJustified;
        pageText.text = "En freemusic tenemos la mejor música para tí, toda la música a tu alcance completamente gratis, solo haz click en botón de descarga para acceder.";
        return textObject;
    }
}
