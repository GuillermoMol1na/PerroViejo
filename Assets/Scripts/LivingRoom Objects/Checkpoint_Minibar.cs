using UnityEngine;

public class Checkpoint_Minibar : MonoBehaviour
{
    private GameMaster  gm;
    public Collider2D miniBarColl;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player= PlayerMovement.FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
         if(player.baseColl.IsTouching(miniBarColl) && Input.GetKeyDown(KeyCode.F)){
            gm.glassfull= false;
            //New conf
            PlayerPrefs.SetInt("minibar",0);
            Debug.Log("Se ha vaciado el vaso");
        }
    }
}
