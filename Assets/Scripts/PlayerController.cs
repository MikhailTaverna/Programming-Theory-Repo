using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gameManager;
    private float verticalInput;
    private float horizontalInput;
    [SerializeField] float speed;
    private float xBound = 13.5f;
    private float upperBound = 7;
    private float lowerBound = -6;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move(); //ABSTRACTION
        BoundaryCheck(); //ABSTRACTION
    }
    void Move()
    {
        if (gameManager.isGameActive)
        {
            verticalInput = Input.GetAxis("Vertical");
            horizontalInput = Input.GetAxis("Horizontal");
            //transform.Translate(Vector3.forward * speed * verticalInput * Time.deltaTime);
            transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
        }
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
    private void OnTriggerEnter(Collider other)
    {
        if (gameManager.isGameActive)
        {
            if (other.gameObject.CompareTag("Food"))
            {
                Debug.Log("Player ate chicken");
                Destroy(other.gameObject);
                gameManager.AddScore(other.gameObject.GetComponent<MoveEnemyChickens>().points);
            }
            else if (other.gameObject.CompareTag("Enemy"))
            {
                Debug.Log("Game Over");
                Destroy(other.gameObject);
                gameManager.isGameActive = false;
                gameManager.GameOver();
            }
        }
    }
}
