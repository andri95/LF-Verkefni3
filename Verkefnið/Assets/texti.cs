using UnityEngine;
using UnityEngine.UI;

public class texti : MonoBehaviour
{
    //public GameManager gameManager;
    public Text scoreText;
    public Text sigrarText;
    public Text topText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Líf: " + GameManager.lif.ToString() + " / Sigrar: " + GameManager.sigrar.ToString() + " / Töp: " + GameManager.top.ToString();
        //sigrarText.text = "Sigrar: " + GameManager.sigrar.ToString();
        //topText.text = "Töp :" + GameManager.top.ToString();
    }
}

