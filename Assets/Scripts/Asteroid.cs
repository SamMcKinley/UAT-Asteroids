﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float offset;
    public float moveSpeed;
    public Vector3 target;


    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemiesList.Add(this.gameObject);
        target = GameManager.instance.Player.transform.position;

        RotateTowards();
        //Aim at the player at start
    }

    // Update is called once per frame
    void Update()
    {
        MoveForward();
        //Always move forward
    }

    void OnDestroy()
    {

    }

    public void Die()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    void RotateTowards()
    {
        Vector3 Direction = target - transform.position;
        target.Normalize();
        float angleToLook = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - offset;
        transform.rotation = Quaternion.Euler(0, 0, angleToLook);
    }

    void MoveForward()
    {
        transform.position += transform.right * Time.deltaTime * moveSpeed;
    }
    void OnCollisionEnter2D(Collision2D OtherObject)
    {
        if (OtherObject.gameObject == GameManager.instance.Player)
        {
            OtherObject.gameObject.GetComponent<Player>().Die();
            this.Die();
        }
    }
}

