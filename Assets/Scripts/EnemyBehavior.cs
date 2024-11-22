using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter (Collider other){
        if(other.name == "Player"){
            Debug.Log("Player detected - atack!");
        }
    }

    void OnTriggerExit(Collider other){
        if(other.name == "Player"){
            Debug.Log("Player out of range, resume patrol");
        }
    }
}
