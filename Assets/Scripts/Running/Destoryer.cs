using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryer : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.name != "Ground" || other.tag != "Finish")
        {
        Destroy(other.gameObject);

        }
    }
  
}
