using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;                                 //체력을 선언 한다. (int)
    public float Timer = 1.0f;                              //타이머 변수를 선언 한다. (float)
    public int AttackPoint = 50;                            //공격력을 선언 한다. 
    //최초 프레임이 업데이트 되기 전 한 번 실행 된다.
    void Start()
    {
        Health = 100;                                      //이 스크립트가 실행 될 때 100을 더 올려준다.
    }

    //게임 진행중인 매 프레임 마다 호출된다.
    void Update()
    {

        CharacterHealthUp();

        if (Input.GetKeyDown(KeyCode.Space))            //스페이스 키를 눌렀을 때
        {
            Health -= AttackPoint;                   //체력 포인트를 공격 포인트 만큼 감소 시켜준다. (Health = Health - AttackPoint)
        }

        CheckDeath();
    }

    public void CharacterHit(int Damage)             //데미지를 받는 함수를 선언 한다.
    {
        Health -= Damage;                   //받은 공격력에 대한 체력을 감소 시킨다.
    }
    void CheckDeath()                      //체력을 검사하는 함수를 선언
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void CharacterHealthUp()
    {
        Timer -= Time.deltaTime;                //시간을 매 프레임마다 감소 시킨다. (deltaTime 프레임 간격의 시간을 의미합니다)
                                                //(Timer = Timer - Time.dealtaTime)
        if (Timer <= 0)                       //만약 Timer의 수치가 0 이하로 내려갈 경우 (1초마다 동작되는 행동을 만들 때)
        {
            Timer = 1;
            Health += 10;
        }
    }
    
        

}
