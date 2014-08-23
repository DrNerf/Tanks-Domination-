using UnityEngine;
using System.Collections;

public class ShootingController : MonoBehaviour 
{
    public Transform ShootPosition;
    public float BulletSpeed = 2;
    public int MachineGunBullets = 20;
    public GameObject Bullet;
    public GameObject BigBullet;
    public GameObject SmallBullet;
    public GameObject Homing;

    public bool Cooldown = false;
    public bool HaveLaser = false;
    public bool HaveBigBang = false;
    public bool HaveMachineGun = false;
    public bool HaveHoming = false;

    public GameObject LaserGun;
    public GameObject BigGun;
    public GameObject MachineGun;

    public string FireKey;
	// Update is called once per frame
	void Update ()
    {
        SetGuns();

        if (Input.GetKeyDown(FireKey) && !Cooldown && !HaveLaser && !HaveBigBang && !HaveMachineGun && !HaveHoming)
        {
            GameObject TempBullet = Instantiate(Bullet, ShootPosition.position, Quaternion.identity) as GameObject;
            TempBullet.GetComponent<CooldownController>().ParentTank = this;
            TempBullet.rigidbody.AddForce(ShootPosition.forward * BulletSpeed);
            Destroy(TempBullet, 15);
            Cooldown = true;
        }

        if (Input.GetKeyDown(FireKey) && HaveLaser)
        {
            GameObject TempBullet = Instantiate(Bullet, ShootPosition.position, Quaternion.identity) as GameObject;
            TempBullet.GetComponent<CooldownController>().ParentTank = this;
            TempBullet.GetComponent<TrailRenderer>().enabled = true;
            TempBullet.renderer.enabled = false;
            TempBullet.rigidbody.AddForce(ShootPosition.forward * BulletSpeed * 5);
            Destroy(TempBullet, 2);
            HaveLaser = false;
        }

        if (Input.GetKeyDown(FireKey) && HaveBigBang)
        {
            GameObject TempBullet = Instantiate(BigBullet, ShootPosition.position, Quaternion.identity) as GameObject;
            TempBullet.GetComponent<CooldownController>().ParentTank = this;
            TempBullet.rigidbody.AddForce(ShootPosition.forward * BulletSpeed);
            Destroy(TempBullet, 15);
            HaveBigBang = false;
        }

        if (Input.GetKeyDown(FireKey) && HaveMachineGun)
        {
            StartCoroutine("FireMachineGun");
            HaveMachineGun = false;
        }

        if (Input.GetKeyDown(FireKey) && HaveHoming)
        {
            GameObject TempBullet = Instantiate(Homing, ShootPosition.position, Quaternion.identity) as GameObject;
            TempBullet.rigidbody.AddForce(ShootPosition.forward * BulletSpeed);
            Destroy(TempBullet, 15);
            HaveHoming = false;
        }

        if (Input.GetKeyUp(FireKey))
        {
            StopCoroutine("FireMachineGun");
        }
	}

    void SetGuns()
    {
        LaserGun.SetActive(HaveLaser);
        BigGun.SetActive(HaveBigBang);
        MachineGun.SetActive(HaveMachineGun);
    }

    IEnumerator FireMachineGun()
    {
        for (int i = 0; i < MachineGunBullets; i++)
        {
            GameObject TempBullet = Instantiate(SmallBullet, ShootPosition.position, Quaternion.identity) as GameObject;
            TempBullet.GetComponent<CooldownController>().ParentTank = this;
            TempBullet.rigidbody.AddForce(ShootPosition.forward * BulletSpeed);
            Destroy(TempBullet, 15);
            yield return new WaitForSeconds(0.1f);
        }
    }

    public bool CheckForWeapons()
    {
        if (HaveBigBang || HaveHoming || HaveLaser || HaveMachineGun)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
