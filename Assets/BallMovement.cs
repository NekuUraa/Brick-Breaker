using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public GameObject _Enemy;
    private List<GameObject> _objects = new List<GameObject>();
    public float _ballSpeed = 2.5f;
    private bool _dirX;
    private bool _dirZ;

    void Start()
    {
        _dirX = true;
        _dirZ = true;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        
            if (_dirX == true && _dirZ == true)
            {

                transform.position = new Vector3(transform.position.x - (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z - (_ballSpeed * Time.deltaTime));

            }

            if (_dirX == true && _dirZ == false)
            {

                transform.position = new Vector3(transform.position.x - (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z + (_ballSpeed * Time.deltaTime));

            }

            if (_dirX == false && _dirZ == true)
            {

                transform.position = new Vector3(transform.position.x + (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z - (_ballSpeed * Time.deltaTime));

            }

            if (_dirX == false && _dirZ == false)
            {

                transform.position = new Vector3(transform.position.x + (_ballSpeed * Time.deltaTime), transform.position.y, transform.position.z + (_ballSpeed * Time.deltaTime));

            }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Destroy(gameObject);
            _dirZ = !_dirZ;
        }

        if(other.tag == "Player")
        {
            _dirZ = false;
        }
    }

}
