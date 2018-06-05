using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Use this for initialization


    public bool canTrippleShot = false;

    [SerializeField]
    public GameObject _laserPrefab;
    [SerializeField]
    private GameObject _trippleShotPrefab;
    [SerializeField]
    private float _fireRate = 0.25f;
    public float _canFire = 0.0f;
    [SerializeField]
    private float _speed = 0.5f;

   

 
    private void Start ()
    {
        
    }
	
	// Update is called once per frame
	private void Update ()
    {

        Movement();

        startFire();
    }


        
        private void Movement()
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            transform.Translate(Vector3.right * Time.deltaTime * _speed * horizontalInput);
            float verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.up * Time.deltaTime * _speed * verticalInput);


            if (transform.position.y > 0)
            {
                transform.position = new Vector3(transform.position.x, 0, 0);
            }

            else if (transform.position.y < -3.8f)
            {
                transform.position = new Vector3(transform.position.x, -3.8f, 0);

            }

            if (transform.position.x > 9.44f)
            {
                transform.position = new Vector3(-9.44f, transform.position.y, 0);
            }

            else if (transform.position.x < -9.44f)
            {
                transform.position = new Vector3(9.44f, transform.position.y, 0);
            }

         }

        private void startFire ()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (canTrippleShot == true)
            {

                Instantiate(_trippleShotPrefab, transform.position + new Vector3(0.176f, 0.69f, -0.011f), Quaternion.identity);
               
            }

            else if (Time.time > _canFire)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 1.01f, 0), Quaternion.identity);
                _canFire = Time.time + _fireRate;
            }

        }
    }




}
