using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ovinur1 : MonoBehaviour
{
    //Búa til array yfir punkta sem óvinur hreyfir sig á milli
    public Transform[] auto_punktar;

    //Variable fyrir hraða óvinar
    public float hradi;

    //Variable fyrir stöðu óvinar
    private int stada;

    // Start is called before the first frame update
    void Start()
    {
        //Láta óvin1 byrja á fyrsta punkti auto_punktar arraysins
        transform.position = auto_punktar[0].position;
        stada = 0;
    }

    // Update is called once per frame
    void Update()
    {

        //Athuga hvort ovinur sé kominn á endastöð, og senda hann þá á næstu endastöð
        if(transform.position == auto_punktar[stada].position)
        {
            stada++;
        }
        
        if(stada >= auto_punktar.Length)
        {
            stada = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, auto_punktar[stada].position, hradi * Time.deltaTime);
    }
}
