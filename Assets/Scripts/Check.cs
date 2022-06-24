using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameCore_Data;

public class Check : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == pl)
        {
            finished = true;
        }
    }
}
