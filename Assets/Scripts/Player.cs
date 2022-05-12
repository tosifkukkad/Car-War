using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int health = 100;
    int max_health = 100;
    public void GetDamage(int damage)
    {
        health -= damage;
        GameManager.Inst.UpdateBar(health/max_health);
        if (health <= 0)
        {
            GameManager.Inst.GameOver();
            Destroy(gameObject);
        }
    }
}
