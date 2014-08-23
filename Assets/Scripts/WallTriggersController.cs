using UnityEngine;
using System.Collections;

public class WallTriggersController : MonoBehaviour 
{
    public bool IsBackTrigger = false;
    public TankController Tank;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Wall" && !IsBackTrigger)
        {
            Tank.CanFwd = false;
        }
        if (other.tag == "Wall" && IsBackTrigger)
        {
            Tank.CanBwd = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Wall" && !IsBackTrigger)
        {
            Tank.CanFwd = true;
        }
        if (other.tag == "Wall" && IsBackTrigger)
        {
            Tank.CanBwd = true;
        }
    }
}
