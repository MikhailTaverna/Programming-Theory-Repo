using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] float speed;
    private float xBound = 13.5f;
    private float upperBound = 7;
    private float lowerBound = -6;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BoundaryCheck();
    }
    void Move()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
    }
    void BoundaryCheck()
    {
        if(transform.position.x > xBound)
        {
            transform.position = new Vector3(xBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -xBound)
        {
            transform.position = new Vector3(-xBound, transform.position.y, transform.position.z);
        }
        if(transform.position.z > upperBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, upperBound);
        }
        if (transform.position.z < lowerBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, lowerBound);
        }
    }
}
