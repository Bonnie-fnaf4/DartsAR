using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{

    public int maxPosition = 20, minPosition = 10;
    public StrikeConroller strikeConroller;

    private void OnCollisionEnter(Collision collision)
    {
        if (!strikeConroller.Ar)
        {
            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, Random.RandomRange(minPosition, maxPosition));
        }
        //gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, Random.RandomRange(minPosition, maxPosition));
        //gameObject.transform.localPosition = new Vector3(transform.position.x, transform.position.y, Random.RandomRange(minPosition, maxPosition));
    }
}
