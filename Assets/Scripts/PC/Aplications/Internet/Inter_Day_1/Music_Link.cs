using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Music_Link
{
    private RectTransform transicon;
    private RectTransform transText;
    private RectTransform transDownload;
    private Image iconImage;
    private GameObject antText;
    private TMP_Text websiteText;
    private TMP_Text downloadLinkText;
    private TMP_FontAsset theFont;

    public GameObject WebsiteHeader(GameObject icon,Vector2 dimensions, Sprite logo){
        transicon= icon.AddComponent<RectTransform>();
        iconImage = icon.AddComponent<Image>();
        transicon.sizeDelta = dimensions;
        iconImage.sprite = logo;
        return icon;
    }
    public GameObject WebsiteText(GameObject antText,TMP_FontAsset pixelFont){
        antText = new GameObject("WebsiteText");
        websiteText = antText.AddComponent<TextMeshProUGUI>();
        transText= antText.GetComponent<RectTransform>();
        transText.sizeDelta = new Vector2(950.37f, 62.93f);
        websiteText.font = theFont =pixelFont;
        websiteText.fontSize = 30f;
        websiteText.color = new Color32(0,0,0,255);
        websiteText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopJustified;
        websiteText.text = "Descarga todas las canciones que reflejen tu actitud:";
        return antText;
    }
    public GameObject CreateMusicLink(GameObject theMusicLink, string theText){
            downloadLinkText = theMusicLink.AddComponent<TextMeshProUGUI>();
            transDownload = theMusicLink.GetComponent<RectTransform>();
            transDownload.sizeDelta = new Vector2(1103.42f, 63.43f);
            downloadLinkText.font = theFont;
            downloadLinkText.fontSize = 50f;
            downloadLinkText.color = new Color32(63,102,183,255);
            downloadLinkText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.TopJustified;
            downloadLinkText.text= theText; 
            return theMusicLink;
    }

}
