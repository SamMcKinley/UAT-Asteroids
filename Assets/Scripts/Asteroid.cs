using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemiesList.Add(this.gameObject);
        //Aim at the player at start
    }

    // Update is called once per frame
    void Update()
    {
        //Always move forward
    }

    void OnDestroy()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D OtherObject)
    {
        if (OtherObject.gameObject == GameManager.instance.Player)
        {
            Destroy(OtherObject.gameObject);
            Destroy(this.gameObject);
        }
    }
    
}

