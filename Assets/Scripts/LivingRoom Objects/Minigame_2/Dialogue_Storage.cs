using System.Linq;

public  class Dialogue_Storage
{
private System.Random rand;
    public string[,] scamCalls = {
                                    {"¿Qué tal? Como representante de VIGO, deseo brindarle el mejor servicio a nuestro usuario C3842JGR, el señor Erwin Gustavo con paquete platino", "¿Es usted verdad? Si se trata de usted, por favor deme su contraseña para restablecer su cuenta en el sistema."},
                                    {"Muy buenas tardes señor Ritchzen, le habla un representante de VIGO, como sabrá, nuestra base de datos ha sido comprometida, complicando en demasía el servicio que nosotros proporcionamos a usuarios del paquete plata como usted,", "sobre todo en zonas cercanas a la calle Ecuador, donde sabemos que el servicio puede ser deficiente a ratos. Permítame su contraseña y nro de tarjeta y estos problemas se solucionarán en breve."},
                                    {"Saludos don Eduardo, le habla un representante de VIGO, sabemos por lo que usted debe estar pasando", "por lo que le pido que me proporcione su contraseña cuanto antes para solucionar este contratiempo."},
                                    {"Buenas tardes señor Erwin, como representante de VIGO, estoy consciente de la molestia que debe ser para usted como usuario C3842JGR el tener que lidiar con problemas ocasionados por la empresa, pero no se preocupe","tan solo dícteme su contraseña y ningún miembro de la familia Ritchzen Trujo tendrá futuros problemas de conexión."},
                                    {"Muy buenas tardes señor, como representante de la empresa VIGO, debo disculparme por el craso error de la manipulación de sus datos, su usuario marca C3842JGR de paquete plata","nuestro paquete más conocido, por lo que usted si es importante para nosotros, por favor pásenos sus contraseñas y lograremos soluionar éste problema señora Carla."},
                                    {"Buenas, le habla un representante de VIGO, sabemos que su nombre completo es Erwin Gustavo Ritchzen Trujillo, su cuenta es C3842JGR, su paquete es el de plata y vive en la Avenida Indira N°342.","Por favor dícteme su contraseña para poder restaurar sus registros en nuestras bases de datos."},
                                    {"Buenas tardes Señor Erwin, lamentamos mucho lo ocurrido con sus registros y los correspondientes a otros usuarios, la empresa VIGO asume toda la responsabilidad por el inconveniente","su dirección es Avenida Indira N°372 y su paquete es el plata. Agradecemos que su colaboración que va más atrás de 1 año. Por favor dígame su contraseña."},
                                    {"Saludos señor Ritchzen, como representante de VIGO creo que usted se merece unas disculpas por todas éstas molestias, su cuenta es la C3842JGR, plan plata y viene apoyándonos desde septiembre.","Sus datos por favor."},
                                    {"Hola señor Richardson, agradecemos los años que viene apoyando a VIGO,","además de solucionar el problema también podrá ganar una pantalla plana de 46 pulgadas tan pronto nos dé el número de su tarjeta."},
                                    {"Buenas tardes señor Erwin, le habla un representante de VIGO, tenemos en cuenta su prefrencia a nuestra empresa desde hace ya 4 meses en el paquete plata.","Su cuenta es C3842JYP, solo nos hace falta su contraseña para poder restituir su registro."},
                                    {"Hola usuario C3842JGR, buenas tardes, le habla un representante de VIGO, como ya sabe, intentamos restaurar los registros perdidos de nuestra base de datos, especialmente a aquellos que viven en zonas cercanas a la avenida Lira.","Es lo menos que podemos hacer para un cliente con paquete plata desde hace ya 10 semanas.Pero para ello necesitamos su contraseña."},
                                    {"Cordiales saludos estimado cliente de VIGO, le habla un representante de la misma empresa.","Para remendar nuestro craso error le suplicamos que tenga paciencia y nos proporcione su número de tarjeta querido usuario de paquete oro."},
                                    {"Muy buenas tardes señor Ritchzen Trujillo, lamentamos mucho el presente inconveniente y suplicamos por su comprensión.","Para no perder el tiempo le solicitamos su contraseña para que pueda seguir disfrutando de su paquete plata, sabemos que lo necesita al vivir en una zona desventajosa en señal como es la calle Indiro."},
                                    {"Saludos cordiales señor Erwin, le habla un representante de VIGO, de antemano deseo agradecer su preferencia de ya 4 meses en el paquete plata al mismo tiempo que pido disculpas en nombre de la empresa por la pérdida de datos.","Tan solo debe brindarnos su contraseña como ya lleva haciendo todo éste tiempo, y le garantizamos la duración de la banda ancha para usted y el resto de la familia Holden Trujillo."},
                                    {"Hola qué tal señor Erwin, le habla un representante de VIGO, su proveedora de servicios de telecomunicación favorita. Pedimos disculpas por los inconvenientes mientras que agradecemos su preferencia desde enero.","Le prometemos restituir sus registros en un santiamén y mantener activo su paquete platino en cuanto nos dicte su número de tarjeta."},
                                 };
    public string[,] realCall = {
                                    {"Hola, la presente es la llamada verdadera", "¿Qué me dices?"}
                                };
    public string[] ScamConv(int index){
        int lenght = scamCalls.GetLength(1);
        string[] theArray = new string[lenght];
        for(int i=0;i<lenght;i++){
            theArray[i]= scamCalls[index,i];
        }
        return theArray;
    }
    public string[] RealCall(){
        int lenght = realCall.GetLength(1);
        string[] theArray = new string[lenght];
        for(int i=0;i<lenght;i++){
            theArray[i]= realCall[0,i];
        }
        return theArray;
    }
    public int[] RandomOrder(int lenght){
        rand = new System.Random();
        //int length = rand.Next(0,8);
        //Adjust the difficulty on the quantity of scam calls
        //int lenght = scamCalls.GetLength(0);
        int[] thefill = new int[lenght];
        for(int i=0;i<lenght;i++){
            thefill[i]=i;
        }
        thefill = thefill.OrderBy(x=>rand.Next(0,lenght)).ToArray();
        return thefill;
    }
    /*public int NumberofScams(){
        return scamCalls.GetLength(0);
    }*/
}
