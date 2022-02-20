using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemyChickens : AbstactEnemyClass
{
    // Start is called before the first frame update
    [SerializeField] float speed;
    [SerializeField] float bound = 15;
    public int points;
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
        if(transform.position.z > bound || transform.position.z < -bound)
        {
            Destroy(gameObject);
        }
    }
}
