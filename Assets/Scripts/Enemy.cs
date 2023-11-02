using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5f;

    private Vector3 dir;

    private GameObject player;

    private int type = 0;

    public int life = 1;

    public GameObject explosionFactory;


    void Start()
    {
        player = GameObject.Find("Player");
    }

    private void OnEnable()
    {
        int randomNumber = Random.Range(0, 10);

        if (randomNumber < 3)
        {
            type = 1;
        }
        else
        {
            type = 0;
        }

        if (gameObject.name.Contains("EnemyLife3"))
        {
            life = 3;
        }
        else
        {
            life = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (type == 1)
        {
            // 방향 구하기 target - me (벡터의 뺄셈)
            dir = player.transform.position - transform.position;

            // 벡터 크기 1로 만들기
            dir.Normalize();
        }
        else
        {
            dir = Vector3.down;
        }

        // 적 이동 구현
        transform.position += dir * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        // 폭발 효과 공장에서 폭발 효과를 만든다.
        GameObject explosion = Instantiate(explosionFactory);

        // 폭발 효과를 자신의 위치에 위치시킨다.
        explosion.transform.position = transform.position;

        if (other.gameObject.tag == "Bullet")
        {
            life--;
        }

        if (life <= 0)
        {
            // 이 게임오브젝트 제거
            gameObject.SetActive(false);

            // EnemyManager 참조하기
            EnemyManager emManger = GameObject.Find("EnemyManager").GetComponent<EnemyManager>();
            // 적의 종류에 따라서 다른 풀에 저장
            if (gameObject.name.Contains("EnemyLife3"))
            {
                emManger.enemyLife3ObjectPool.Add(gameObject);
            }
            else
            {
                emManger.enemyObjectPool.Add(gameObject);
            }

            // ScoreManger의 Get/Set 프로퍼티
            ScoreManager.Instance.Score++;
        }

        
        // 충돌한 오브젝트가 총알이라면
        if (other.gameObject.tag == "Bullet")
        {
            // 총알을 제거하지 않고 비활성화
            other.gameObject.SetActive(false);

            // PlayerFire를 참조한다
            PlayerFire player = GameObject.Find("Player").GetComponent<PlayerFire>();
            // 총알 오브젝트 풀에 삽입
            player.bulletObjectPool.Add(other.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            // 충돌한 상대 충돌체 제거
            Destroy(other.gameObject);
            GameManager.Instance.StopGame();
        }
    }
}
