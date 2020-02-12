using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Adjust rotation every update for heat seeking behavior
        //Always fly forward
    }

    void OnDestroy()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }
}
