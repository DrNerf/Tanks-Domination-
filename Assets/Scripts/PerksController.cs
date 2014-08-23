using UnityEngine;
using System.Collections;

public class PerksController : MonoBehaviour 
{

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
