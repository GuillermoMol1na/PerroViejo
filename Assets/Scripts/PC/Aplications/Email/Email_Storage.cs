using UnityEngine;

public class Email_Storage
{ 
  public string[,] dayZero = { {"ContactoDelDia_0","Contacto2","Contacto3", "Contacto4", "Contacto5"},
                                {"Asunto 0", "Subject2", "Subject3", "Subject4", "Subjects5"},
                               {"Esto solo sale en día 0", "Email2", "Email3","Email4","Email5"}  };
  public string[,] dayOne = { {"Contacto1","Contacto2","Gladys", "Contacto4", "Contacto5"},
                                {"Subject1", "Descargar Canciones por favor", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "hamilton008796465746757394234532.mp3"+ System.Environment.NewLine+
                               "tomjones634268543977413253633245.mp3"+ System.Environment.NewLine+
                               "julioiglesias8521647932554123974.mp3", "Email3","Email4","Email5"}  };
  public string[,] dayTwo = { {"Contacto1","Contacto2","Contacto3", "Contacto4", "Contacto5"},
                                {"Subject1", "Subject2", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "Email2", "Email3","Email4","Email5"}  };
}
