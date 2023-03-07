using UnityEngine;

public class Bed : MonoBehaviour
{
    public Sprite bedMade;
    public Sprite bedUnmade;
    public Collider2D bedColl;
    public bool confirm= false;
    private GameMaster  gm;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private RedArrowObj redArrow;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        if(gm.BedMade)
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bedMade;
        else
        this.gameObject.GetComponent<SpriteRenderer>().sprite = bedUnmade;
    }
    // Update is called once per frame
    void Update()
    {
        if(player.baseColl.IsTouching(bedColl) && Input.GetKeyDown(KeyCode.F) && !confirm){
            this.gameObject.GetComponent<SpriteRenderer>().sprite = bedMade;
            redArrow.RedArrowVanish();
            confirm=true;
        }else if(player.baseColl.IsTouching(bedColl) && Input.GetKeyDown(KeyCode.F) && !confirm){
            //GUARDAR PARTIDA
        }
    }

}
