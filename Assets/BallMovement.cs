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
    private Vector3 rotate;

    void Start()
    {
        _dirX = true;
        _dirZ = true;
        rotate = new Vector3 (-10,0,0);

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        transform.Rotate(rotate);
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
            other.transform.parent = transform;
            _dirZ = !_dirZ;
            rotate = new Vector3(-10, 0, 0);
        }

        if(other.tag == "Rando")
        {
            other.transform.parent = transform;
        }

        if(other.tag == "Player")
        {
            _dirZ = false;

            rotate = new Vector3(10, 0, 0);
        }

        if(other.tag == "UpBorder")
        {
            _dirZ = true;
            rotate = new Vector3(-10, 0, 0);
        }

        if (other.tag == "LeftBorder")
        {
            _dirX = false;
        }

        if (other.tag == "RightBorder")
        {
            _dirX = true;
        }


        if (other.tag == "DownBorder")
        {
            transform.position = new Vector3(0, 1.29f, 0);
            _dirX= true;
            _dirZ= true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
       /* if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Oui je touche");
            collision.transform.parent = transform;
        }*/
    }

}
