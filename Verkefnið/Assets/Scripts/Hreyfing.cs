using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hreyfing : MonoBehaviour
{
    //Hægt að edita í inspector - Speed
    public float hradi;

    //Variable sem inniheldur prefab fyrir dauða-animation
    public GameObject deyja;

    public Rigidbody rb;

    // Vector xyz til að stjorna leikmanni
    private Vector3 input;

    // Setja cap á hraða - f = float
    private float maxHradi = 7f;

    //
    private Vector3 spawn;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        spawn = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Instance af Vector3 sem tekur inn input frá lyklaborði, 0 fyrir Y axis þar verður engin hreyfing þar
        input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

        if (rb.velocity.magnitude < maxHradi)
        {
            // Stjórna hreyfingu leikmanns - Addforce - Margfalda input með hraða sem er stillt inni í Unity
            rb.AddForce(input * hradi);
        }

        //Sjá hvort leikmaður detti út af velli
        if(transform.position.y < -2)
        {
            Deyja();
            if (GameManager.lif == 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }
        }

        //Ef leikmaður deyr 3x byrjar leikur upp á nýtt
        
    }

    //Collision detection - Sjá hvort leikmaður klessi á óvini eða komist í mark
    void OnCollisionEnter(Collision other)
    {
        //Ef leikmaður klessir á hlut sem hefur Ovinur tagið
        if(other.transform.tag == "Ovinur")
        {
            Deyja();
            if (GameManager.lif == 0)
            {
                FindObjectOfType<GameManager>().EndGame();
            }  
        }
        else if(other.transform.tag == "Goal")
        {
            FindObjectOfType<GameManager>().Sigur();
        }
    }

    //Kalla í particles þar sem leikmaður dó og senda leikmann aftur á byrjunarreit
    void Deyja()
    {
        GameManager.lif--;
        Instantiate(deyja, transform.position, Quaternion.identity);
        transform.position = spawn;
    }
}
