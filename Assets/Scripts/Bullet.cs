using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform tf;
    public float bulletspeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        tf.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        //always move forward
        tf.position += tf.right * bulletspeed * Time.deltaTime;
    }
}
