using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyda : MonoBehaviour
{
    public float liftimi = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, liftimi);
    }
}
