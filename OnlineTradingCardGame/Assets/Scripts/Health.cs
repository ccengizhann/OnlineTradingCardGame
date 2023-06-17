using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int currentHealth;

    private void Start()
    {
        currentHealth = GetComponent<AIMove>().stats.health;
    }

    public void GetHit(int damage)
    {
        currentHealth -= damage;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.GetComponent<AIMove>().team == TeamColor.Blue)
            {
                CardGameManager.Instance.playerMonsters.Remove(gameObject);
                Destroy(gameObject);
                return;
            }
            
            CardGameManager.Instance.enemyMonsters.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
