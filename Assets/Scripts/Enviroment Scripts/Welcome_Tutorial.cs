using UnityEngine;

public class Welcome_Tutorial : MonoBehaviour
{
    private GameMaster gm;
    private MessageTrigger msgTrigg;
    private bool tut=true;
    private bool com;
    private string[] welcomeday0 = {"Bienvenido al juego, presiona [SPACE] para continuar.",
                                    "Lo primero de hoy es hacer la cama, una vez finalizado aquello podrás bajar a la sala.",
                                    "Presiona la tecla [F] en tu teclado para interactuar con tu entorno.",
                                    "No te olvides beber algo y leer un poco antes de encender tu PC.",
                                    "Buena suerte."};
    private string[] welcomeday1 = {"El día de ayer fue informativo, pero el día de hoy las cosas no serán tan sencillas.",
                                    "erwin debe seguir su rutina, pero al finalizar debe revisar su correo.",
                                    "Su amiga Gladys le pidió un favor ayer de todas formas.",
                                    "Buena suerte."};
    private string[] welcomeday2 = {"El día de hoy debes hacer...",
                                    "Al parecer nada.",
                                    "No hay nada claro de momento, por lo que Erwin debe seguir su rutina como siempre.",
                                    "Buena suerte."};
    private string[] enday0 = {"Eso es todo por hoy", "Erwin debe descansar y prepararse para el día siguiente"};
    private string[] enday1;
    private string[] enday2;
    private Messages welcTut = new Messages();
    void Start()
    {  
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        tut= Converter(PlayerPrefs.GetInt("tutorial"));
        com= Converter(PlayerPrefs.GetInt("dayCompleted"));
        if(tut){
            Invoke("ShowMeTutorial",3f);
        }
        PlayerPrefs.SetInt("tutorial",0);
        if(com){
            Invoke("ShowMeEndDayMessage",2f);
        }

    }
    private void ShowMeTutorial(){
        //Debug.Log("El tutorial/dia de hoy es: "+PlayerPrefs.GetInt("day"));
        switch(PlayerPrefs.GetInt("day")){
        case 0:
        welcTut.Include(welcomeday0);
        break;
        case 1:
        welcTut.Include(welcomeday1);
        break;
        case 2:
        welcTut.Include(welcomeday2);
        break;
        }
        msgTrigg.UsetheMessages(welcTut);
        msgTrigg.TriggerMessage();
    }
    private void ShowMeEndDayMessage(){
        
        switch(PlayerPrefs.GetInt("day")){
        case 0:
        welcTut.Include(enday0);
        break;
        case 1:
        enday1 = new string[] {"Eso es todo por hoy", "Lograste finalizar el reto del día en: "+gm.min+":"+gm.sec, "Erwin debe descansar y prepararse para el día siguiente"};
        welcTut.Include(enday1);
        break;
        case 2:
        enday2= new string[] {"Eso es todo por hoy","Lograste evitar las estafas en: "+gm.min+":"+gm.sec, "Eso concluye todo, Erwin debe ir a la cama para finalizar el juego"};
        welcTut.Include(enday2);
        break;
        }
        msgTrigg.UsetheMessages(welcTut);
        msgTrigg.TriggerMessage();
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
