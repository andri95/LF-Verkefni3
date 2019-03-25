
using UnityEngine;
using UnityEngine.SceneManagement;


//Fylgst með sigur/tap/líf eftir ofl.

public class GameManager : MonoBehaviour
{

    //Variable sem heldur utan um líf, er aðgengileg úr öðrum scripts
    public static int lif = 3;

    //Breyta sem heldur utan um hve oft leikmaður hefur unnið
    public static int sigrar = 0;

    //Breyta sem heldur utan um hve oft leikmaður hefur tapað
    public static int top = 0;

    //Boolean breyta sem ég nota til að láta leikinn vita að leikmaður tapaði
    bool tap = false;

    //Set delay á hve lengi leikurinn er að restarta sér
    public float restartDelay = 0.5f;

    //Fall sem heldur utanum hvað gerist ef leikmaður sigrar
    public void Sigur()
    {
        sigrar++;
        tap = true;
        Invoke("Restart", restartDelay);
    }

    //Fall sem "invoke"-ar restart eftir að restartDelay er liðið
    public void EndGame()
    {
        if(lif == 0)
        {
            tap = true;
            Invoke("Restart", restartDelay);
        }
    }

    //Senan loadast aftur og líf leikmanns er resettað í 3
    void Restart()
    {
        lif = 3;
        top++;
        SceneManager.LoadScene("Sena1");
    }
}
