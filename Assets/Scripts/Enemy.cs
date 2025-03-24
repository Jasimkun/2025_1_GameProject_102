using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int Health = 100;                                 //ü���� ���� �Ѵ�. (int)
    public float Timer = 1.0f;                              //Ÿ�̸� ������ ���� �Ѵ�. (float)
    public int AttackPoint = 50;                            //���ݷ��� ���� �Ѵ�. 
    //���� �������� ������Ʈ �Ǳ� �� �� �� ���� �ȴ�.
    void Start()
    {
        Health = 100;                                      //�� ��ũ��Ʈ�� ���� �� �� 100�� �� �÷��ش�.
    }

    //���� �������� �� ������ ���� ȣ��ȴ�.
    void Update()
    {

        CharacterHealthUp();

        if (Input.GetKeyDown(KeyCode.Space))            //�����̽� Ű�� ������ ��
        {
            Health -= AttackPoint;                   //ü�� ����Ʈ�� ���� ����Ʈ ��ŭ ���� �����ش�. (Health = Health - AttackPoint)
        }

        CheckDeath();
    }

    public void CharacterHit(int Damage)             //�������� �޴� �Լ��� ���� �Ѵ�.
    {
        Health -= Damage;                   //���� ���ݷ¿� ���� ü���� ���� ��Ų��.
    }
    void CheckDeath()                      //ü���� �˻��ϴ� �Լ��� ����
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void CharacterHealthUp()
    {
        Timer -= Time.deltaTime;                //�ð��� �� �����Ӹ��� ���� ��Ų��. (deltaTime ������ ������ �ð��� �ǹ��մϴ�)
                                                //(Timer = Timer - Time.dealtaTime)
        if (Timer <= 0)                       //���� Timer�� ��ġ�� 0 ���Ϸ� ������ ��� (1�ʸ��� ���۵Ǵ� �ൿ�� ���� ��)
        {
            Timer = 1;
            Health += 10;
        }
    }
    
        

}
