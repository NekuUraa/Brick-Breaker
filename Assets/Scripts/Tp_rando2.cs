using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp_rando2 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rando3")
        {
            Debug.Log("oui c'est moi le navmesh");
            other.gameObject.transform.position = new Vector3(24.57f, 1.35f, Random.Range(9.45f, -6.6f));
        }

        if (other.tag == "Rando4")
        {
            Debug.Log("oui c'est moi le navmesh");
            other.gameObject.transform.position = new Vector3(24.57f, 1.35f, Random.Range(9.45f, -6.6f));
        }
    }
}
