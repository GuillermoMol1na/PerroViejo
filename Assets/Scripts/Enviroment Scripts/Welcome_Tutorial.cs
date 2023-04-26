using UnityEngine;

public class Welcome_Tutorial : MonoBehaviour
{
    private GameMaster  gm;
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
    private string[] enday = {"Eso es todo por hoy", "Erwin debe descansar y prepararse para el día siguiente"};
    private Messages welcTut = new Messages();
    void Start()
    {
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        tut= Converter(PlayerPrefs.GetInt("tutorial"));
        com= Converter(PlayerPrefs.GetInt("dayCompleted"));
        if(tut){
            Invoke("ShowMeTutorial",2f);
        }
        PlayerPrefs.SetInt("tutorial",0);
        if(com){
            Invoke("ShowMeEndDayMessage",2f);
        }

    }
    private void ShowMeTutorial(){
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
        welcTut.Include(enday);
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
