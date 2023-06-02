using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strike : MonoBehaviour
{
    public Rigidbody rigidbody;

    public StrikeConroller strikeConroller;

    Quaternion quaternion = new Quaternion();
    bool isDead = false;
    public Collider collider;

    void Start()
    {
        collider = GetComponent<Collider>();
        quaternion = transform.rotation;
        rigidbody = GetComponent<Rigidbody>();
        //Vector3 vector3 = new Vector3(0,450, 450);
        //rigidbody.AddForce(vector3);
        //Destroy(gameObject, 5);
    }

    private void Update()
    {
        if (!isDead)
        {
            quaternion = Quaternion.Euler(quaternion.eulerAngles.x + (30 * Time.deltaTime), quaternion.eulerAngles.y, quaternion.eulerAngles.z);
            transform.rotation = quaternion;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.other.tag == "Enemy" || collision.other.tag == "Enemy2" || collision.other.tag == "Ground")
        {
            isDead = true;
            rigidbody.isKinematic = true;
            rigidbody.useGravity = false;
            transform.parent = collision.transform;
            collider.isTrigger = true;

            if (collision.other.tag == "Enemy") strikeConroller.ScoreInt++;
            if (collision.other.tag == "Enemy2") strikeConroller.ScoreInt += 5;
            //if (collision.other.tag == "Enemy") transform.localScale = new Vector3(5, 5, 1);
        }
    }

    public void StartStrike(float forseToStrike)
    {
        rigidbody = GetComponent<Rigidbody>();
        Vector3 vector3 = new Vector3(0,450 * forseToStrike, 450 * forseToStrike);
        rigidbody.AddForce(vector3);
        Destroy(gameObject, 5);
    }
}
