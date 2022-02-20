using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyDog : AbstactEnemyClass
{
    [SerializeField] float speed;
    [SerializeField] float bound = 15;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        BoundaryCheck();
    }
    protected override void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    protected override void BoundaryCheck()
    {
        if (transform.position.z > bound || transform.position.z < -bound)
        {
            Destroy(gameObject);
        }
    }
}
