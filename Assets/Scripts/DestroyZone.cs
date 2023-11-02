using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyZone : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet" || other.gameObject.tag == "Enemy")
        {
            other.gameObject.SetActive(false);

            if (other.gameObject.tag == "Bullet")
            {
                PlayerFire player = GameObject.FindWithTag("Player").GetComponent<PlayerFire>();
                player.bulletObjectPool.Add(other.gameObject);
            }
            else if (other.gameObject.tag == "Enemy")
            {
                EnemyManager emManager = FindObjectOfType<EnemyManager>();
                if (other.gameObject.name.Contains("EnemyLife3"))
                {
                    emManager.enemyLife3ObjectPool.Add(other.gameObject);
                }
                else
                {
                    emManager.enemyObjectPool.Add(other.gameObject);
                }
            }
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}
