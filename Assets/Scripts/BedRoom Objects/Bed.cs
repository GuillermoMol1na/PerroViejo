using UnityEngine;

public class Bed : MonoBehaviour
{
    public Sprite bedMade;
    public Sprite bedUnmade;
    public Collider2D bedColl;
    public bool confirm= false;
    public bool com;
    private GameMaster  gm;
    private MessageTrigger msgTrigg;
    [SerializeField] private Collider2D playerCol;
    [SerializeField] private RedArrowObj redArrow;
    private string[] confirmSave = {"¿Deseas Guardar la partida?"};
    private string[] acceptSave = {"Partida Guardada"};
    private Messages mkBedMsg = new Messages();
    public delegate void SelectOptions();
    public static event SelectOptions showTheOptions;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        mkBedMsg.Include(confirmSave);
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        if(gm.BedMade)
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bedMade;
        else
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bedUnmade;
        com = Converter(PlayerPrefs.GetInt("dayCompleted"));
    }
    private void showtheAcceptMessages(){
        mkBedMsg.Include(acceptSave);
        msgTrigg.UsetheMessages(mkBedMsg);
        msgTrigg.TriggerMessage();
    }
    void Update()
    {
        if(playerCol.IsTouching(bedColl) && Input.GetKeyDown(KeyCode.F) && confirm && com){
            //GUARDAR PARTIDA y usar PlayerPrefabs para reiniciar glass y demás en GameMaster
            
            msgTrigg.UsetheMessages(mkBedMsg);
            msgTrigg.TriggerMessage();
            showTheOptions();
            Debug.Log("Pues ya deberían ser visibles");
            //PlayerPrefs.SetInt("day",1);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && Input.GetKeyDown(KeyCode.F) && !confirm){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bedMade;
            redArrow.RedArrowVanish();
            confirm=true;
        }
    }
    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" && confirm && com){
            //GUARDAR PARTIDA y usar PlayerPrefabs para reiniciar glass y demás en GameMaster
            
            msgTrigg.UsetheMessages(mkBedMsg);
            msgTrigg.TriggerMessage();
            showTheOptions();
            Debug.Log("Pues ya deberían ser visibles");
            //PlayerPrefs.SetInt("day",1);
        }
    }*/
    void OnEnable(){
        Options_Answers.showAccept += showtheAcceptMessages;
    }
    void OnDisable(){
        Options_Answers.showAccept -= showtheAcceptMessages;
    }

    private bool Converter(int num){
        if(num == 1){
            return true;
        }
        else{
            return false;
        }
    }
}
