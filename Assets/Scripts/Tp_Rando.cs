using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tp_Rando : MonoBehaviour
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
        if (other.tag == "Rando")
        {
            Debug.Log("oui c'est moi le navmesh");
            other.gameObject.transform.position = new Vector3(-17.03f, 1.35f, Random.Range(9.45f, -6.6f));
        }

        if (other.tag == "Rando2")
        {
            Debug.Log("oui c'est moi le navmesh");
            other.gameObject.transform.position = new Vector3(-17.03f, 1.35f, Random.Range(9.45f, -6.6f));
        }
    }
}
