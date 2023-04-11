using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InterWind : MonoBehaviour
{
    private Minigame_1 theMinigame;
    private GameObject link;
    private Vector2 linkSize;
    private Vector2 thePosition;
    public TabGroup tabGroup;
    private RectTransform imgtrans;
    public Image imageOfSprite;
    private float posX;
    private float posY;
    private float lastHeight;
    private float halfHeight;
    private float lastHalf;
    private float maxHeightY=19789f;


    void Start()
    {
        theMinigame = Minigame_1.FindObjectOfType<Minigame_1>();
        if(this.transform.name == "FirstElement"){
            this.gameObject.SetActive(true);
        }else{
            this.gameObject.SetActive(false);
            AddTheLinks(theMinigame.Reshuffle());
        }
        tabGroup.WindowSystem(this.gameObject);
    }
    public void DeleteWind(){
        this.gameObject.SetActive(false);
        Destroy(this);
    }
    public void AddTheLinks(Sprite[] thesprite){

        posX = -30248f;
        for(int i=0; i<10;i++){
        //Creating the link
        link = new GameObject("ICONO_"+i.ToString());

        imgtrans = link.AddComponent<RectTransform>();
        linkSize= thesprite[i].bounds.size*2.5f;
        imgtrans.sizeDelta = linkSize;
        halfHeight= thesprite[i].bounds.size.y * 60f;
        switch(i){
            case 0:
                posY = maxHeightY-halfHeight;
            break;
            case 5:
                posX=30397;
                posY = maxHeightY-halfHeight;
            break;
            default:
                posY = lastHeight - (halfHeight+lastHalf+ 500f);
            break;
        }
 
        lastHeight=posY;
        lastHalf=halfHeight;

        thePosition = new Vector2(posX,posY);

        imageOfSprite = link.AddComponent<Image>();
        imageOfSprite.sprite = thesprite[i];

        link.transform.SetParent(this.transform);
        link.transform.localPosition = thePosition;
        
        }


    }

}
