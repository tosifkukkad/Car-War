using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GunSystem Gun;
    public int health = 100;
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.LookAt(other.transform);
            Gun.MyInput(true);
        }
    }

    public void GetDamage(int damage) {
        health -= damage;
        if (health <= 0)
        {
            GameManager.Inst.KillRobo();
            Destroy(gameObject);
        }
    }
}
