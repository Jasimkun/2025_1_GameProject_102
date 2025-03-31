using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)          //충돌이 일어났을 때 호출되는 함수
    {
        if(collision.gameObject.tag == "Ground")           //충돌이 일어난 물체의 tag가 Ground
        {
            Debug.Log("땅과 충돌");                      //충돌이 일어났을 경우 로그로 확인한다
        }
    }

    void OnTriggerEnter(Collider other)                //트리거 영역 안에 들어왔다를 감시하는 함수
    {
        Debug.Log("큐브 범위 안에 들어옴");
    }
}
