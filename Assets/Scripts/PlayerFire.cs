using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    // 총알 공장
    public GameObject bulletFactory;
    // 총구
    public GameObject firePosition;

    // 오브젝트 풀 크기
    public int poolSize = 10;

    // 오브젝트 풀 배열
    public List<GameObject> bulletObjectPool;


    void Start()
    {
        // 오브젝트 풀 배열을 풀 크기만큼 생성
        bulletObjectPool = new List<GameObject>();

        // 오브젝트 풀 크기만큼 반복하여
        for (int i = 0; i < poolSize; i++)
        {
            // 총알을 미리 생성하여
            GameObject bullet = Instantiate(bulletFactory);
            // 총알을 오브젝트 풀에 할당한다
            bulletObjectPool.Add(bullet);
            // 총알을 비활성화 해준다
            bullet.SetActive(false);
        }

#if UNITY_ANDROID
        GameObject.Find("Joystick canvas XYBZ").SetActive(true);
#elif UNITY_EDITOR || UNITY_STANDALONE
        GameObject.Find("Joystick canvas XYBZ").SetActive(false);
#endif
    }

    void Update()
    {
#if UNITY_EDITOR || UNITY_STANDALONE
        // 사용자가 발사 버튼을 누르면
        if (Input.GetButtonDown("Fire1"))
        {
            Fire();
        }
#endif
    }

    public void Fire()
    {
        // 만약 탄창안에 총알이 있다면
        if (bulletObjectPool.Count > 0)
        {
            // 탄창에서 총알을 하나 가져온다
            GameObject bullet = bulletObjectPool[0];
            // 총알을 활성화 한다
            bullet.SetActive(true);
            // 오브젝트풀에서 총알 제거
            bulletObjectPool.Remove(bullet);

            // 총알을 총구 위치로 한다
            bullet.transform.position = transform.position;
        }
    }
}
