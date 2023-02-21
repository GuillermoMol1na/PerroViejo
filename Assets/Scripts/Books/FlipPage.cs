using UnityEngine;
using TMPro;

public class FlipPage : MonoBehaviour
{
    private int numPages=3;
    private int index=0;
    private TMP_Text[] pageArr;
    public TMP_Text Pag1;
    public TMP_Text Pag2;
    public TMP_Text Pag3;
    // Start is called before the first frame update
    void Start(){
        pageArr = new TMP_Text[numPages];
        pageArr[0] = Pag1;
        pageArr[1] = Pag2;
        pageArr[1].enabled =false;
        pageArr[2] = Pag3;
        pageArr[2].enabled=false;
    }
    public void PreviousPage(){
        if(index-1 < 0){
            Activateonlyone(numPages-1);
            index=2;
        }
        else{
            Activateonlyone(index-1);
            index--;
        }
    }
    public void NextPage(){
        if(index+1 == numPages){
            Activateonlyone(0);
            index=0;
        }
        else{
            Activateonlyone(index+1);
            index++;
        }
    }
    public void Activateonlyone(int a){
        for(int i=0; i<numPages; i++){
            if(i==a){
                pageArr[i].enabled=true;
            }
            else{
                pageArr[i].enabled=false;
            }
        }
    }
}
