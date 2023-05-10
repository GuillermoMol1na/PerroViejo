using System.Linq;
public class Difficulty_Minigame2
{
    private float theTimeEasy= 420;
    private float theTimeMedium = 300;
    private float theTimeHard = 180;
    private System.Random rand;
    
    public float EasyTime(){
        return theTimeEasy;
    }
    public float MediumTime(){
        return theTimeMedium;
    }
    public float HardTime(){
        return theTimeHard;
    }
    public int numberOfCallsEasy(){
        rand = new System.Random();
        return rand.Next(3,6);
    }
    public int numberOfCallsMedium(){
        rand = new System.Random();
        return rand.Next(6,10);
    }
    public int numberOfCallsHard(){
        rand = new System.Random();
        return rand.Next(11,15);
    }
}
