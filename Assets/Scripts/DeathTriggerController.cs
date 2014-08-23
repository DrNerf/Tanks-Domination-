using UnityEngine;
using System.Collections;

public class DeathTriggerController : MonoBehaviour 
{
    public GameObject ParentTank;
    public GameObject DeathExplosion;

    void OnTriggerEnter(Collider other)
    {
        if (!ParentTank.GetComponent<ShootingController>().CheckForWeapons())
        {
            if (other.tag == "Bullet")
            {
                Instantiate(DeathExplosion, transform.position, Quaternion.identity);
                Destroy(other.gameObject);
                Destroy(ParentTank);
            }

            if (other.tag == "LaserPerk")
            {
                ParentTank.GetComponent<ShootingController>().HaveLaser = true;
                Destroy(other.gameObject);
            }

            if (other.tag == "BigBangPerk")
            {
                ParentTank.GetComponent<ShootingController>().HaveBigBang = true;
                Destroy(other.gameObject);
            }

            if (other.tag == "MachineGunPerk")
            {
                ParentTank.GetComponent<ShootingController>().HaveMachineGun = true;
                Destroy(other.gameObject);
            }

            if (other.tag == "HomingPerk")
            {
                ParentTank.GetComponent<ShootingController>().HaveHoming = true;
                Destroy(other.gameObject);
            }
        }
    }
	
}
