using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.PlayerSettings;

public class AgentNavigator : MonoBehaviour
{

    private NavMeshAgent myAgent;
    public GameObject goalDestination;
    public GameObject ball;
    public float _speed;

    public bool noLongerAI = false;

  
    // Start is called before the first frame update
    void Start()
    {
         myAgent = GetComponent<NavMeshAgent>();
        _speed = Random.Range(3f, 5f);
        myAgent.speed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (noLongerAI == false)
        {
            myAgent.destination = goalDestination.transform.position;
        }
        
        if (noLongerAI == true)
        {
            myAgent.enabled = !myAgent.enabled;
        }
    }

    


}
