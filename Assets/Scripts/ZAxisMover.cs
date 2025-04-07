using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//5초 동안 5의 스피드로 앞으로 이동하고 사라지는 컴포넌트 클래스 (오브젝트에서의 앞 Z 축)
public class ZAxisMover : MonoBehaviour        //Z축으로 이동하는 클래스
{
    public float speed = 5.0f;                  //이동 속도 선언
    public float timer = 5.0f;                  //타이머 설정

    // Update is called once per frame
    void Update()
    {
        //Z축 방향으로 앞으로 이동
        transform.Translate(0,0,speed *  Time.deltaTime);  //Z축 방향으로 앞으로 이동 [Translate 함수를 사용하여]

        timer -= Time.deltaTime;                            //시간을 카운트 다운 한다
        if (timer < 0)                                      //시간이 만료되면
        { 
            Destroy(gameObject);                           //자기 자신을 파괴한다.
        }
    }
}
