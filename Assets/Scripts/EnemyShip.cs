using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShip : MonoBehaviour
{
    public float moveSpeed;
    public Vector3 target;
    public float offset;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.enemiesList.Add(this.gameObject);
        RotateTowardsInstantly();
    }

    // Update is called once per frame
    void Update()
    {
        RotateTowardsGradually();
        MoveForward();
        //Adjust rotation every update for heat seeking behavior
        //Always fly forward
    }

    void OnDestroy()
    {

    }

    public void Die()
    {
        GameManager.instance.enemiesList.Remove(this.gameObject);
        Destroy(this.gameObject);
    }

    void RotateTowardsInstantly()
    {
        target = GameManager.instance.Player.transform.position;
        Vector3 Direction = target - transform.position;
        target.Normalize();
        float angleToLook = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - offset;
        transform.rotation = Quaternion.Euler(0, 0, angleToLook);
    }

    void RotateTowardsGradually()
    {
        target = GameManager.instance.Player.transform.position;
        Vector3 Direction = target - transform.position;
        target.Normalize();
        float angleToLook = Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg - offset;
        Quaternion targetLocation = Quaternion.Euler(0, 0, angleToLook);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetLocation, rotationSpeed * Time.deltaTime);
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
