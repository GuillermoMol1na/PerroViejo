using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Contact_Subject_Creation
{

    private GameObject contactTMP;
    private GameObject subjectTMP;


    public GameObject createCon(TMP_FontAsset pixelFont, int index, string contactoString){
            contactTMP =  new GameObject("TextContact");
            TMP_Text contactText = contactTMP.AddComponent<TextMeshProUGUI>();
            RectTransform transTMP = contactTMP.GetComponent<RectTransform>();
            transTMP.anchoredPosition = new Vector2(0f, 0f);
            transTMP.offsetMin = new Vector2(0,0);
            transTMP.offsetMax = new Vector2(0,0);
            transTMP.localPosition = new Vector3(-13543f, -1963.9f, 0);
            transTMP.pivot=new Vector2(0.5f, 0.5f);
            transTMP.sizeDelta = new Vector2(18704.46f, 3048.29f);
            contactText.font = pixelFont;
            contactText.fontSize= 2000f;
            contactText.color = new Color32(108,108,108,255);
            contactText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
            contactText.text=contactoString;
            return contactTMP;
    }
    public GameObject createSub(TMP_FontAsset pixelFont, int index, string subjectString){
            subjectTMP =  new GameObject("TextSubject");
            TMP_Text subjectText = subjectTMP.AddComponent<TextMeshProUGUI>();
            RectTransform transTMP = subjectTMP.GetComponent<RectTransform>();
            transTMP.anchoredPosition = new Vector2(0f, 0f);
            transTMP.offsetMin = new Vector2(0,0);
            transTMP.offsetMax = new Vector2(0,0);
            transTMP.localPosition = new Vector3(376.4f, 1048.6f, 0);
            transTMP.pivot=new Vector2(0.5f, 0.5f);
            transTMP.sizeDelta = new Vector2(46885.76f, 3927.6f);
            subjectText.font = pixelFont;
            subjectText.fontSize= 3000f;
            subjectText.color = new Color32(50,50,50,255);
            subjectText.GetComponent<TextMeshProUGUI>().alignment = TextAlignmentOptions.Left;
            subjectText.text=subjectString;
            return subjectTMP;
    }
}
