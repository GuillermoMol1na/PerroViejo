using UnityEngine;

public class Email_Storage
{
  public string[] theEmails= {"Aquí está el contenido del Email 1",
                                "Este es el email2",
                                "Email numero 3",
                                "Email 4",
                                "Email 5",
                                "EL EMAIL SE MUESTRA",
                                "EL EMAIL SE MUESTRA",
                                "EL EMAIL SE MUESTRA",
                                "EL EMAIL SE MUESTRA",
                                "EL EMAIL SE MUESTRA"};
  public string[] theContacts={"Contacto",
                                "Amarillo",
                                "Hijo",
                                "Gladd",
                                "Russ"};
  public string[] theSubjects={"ALGO1",
                                "ALGO2",
                                "ALGO3",
                                "ALGO4",
                                "ALGO5"};

  
  public string[,] dayZero = { {"ContactoDelDia_0","Contacto2","Contacto3", "Contacto4", "Contacto5"},
                                {"Asunto 0", "Subject2", "Subject3", "Subject4", "Subjects5"},
                               {"Esto solo sale en día 0", "Email2", "Email3","Email4","Email5"}  };
  public string[,] dayOne = { {"Contacto1","Contacto2","Contacto3", "Contacto4", "Contacto5"},
                                {"Subject1", "Subject2", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "Email2", "Email3","Email4","Email5"}  };
  public string[,] dayTwo = { {"Contacto1","Contacto2","Contacto3", "Contacto4", "Contacto5"},
                                {"Subject1", "Subject2", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "Email2", "Email3","Email4","Email5"}  };
}
