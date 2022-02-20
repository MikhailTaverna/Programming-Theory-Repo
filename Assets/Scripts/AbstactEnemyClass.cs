using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstactEnemyClass : MonoBehaviour
{
    // Start is called before the first frame update
    protected abstract void Move();
    protected abstract void BoundaryCheck();
}
