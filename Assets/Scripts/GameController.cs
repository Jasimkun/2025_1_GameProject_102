using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public float Timer = 1.0f;
    public GameObject EnemyObject;

    void Update()
    {
        Timer -= Time.deltaTime;                //시간을 매 프레임마다 감소 시킨다. (deltaTime 프레임 간격의 시간을 의미합니다)
                                                //(Timer = Timer - Time.dealtaTime)
        if (Timer <= 0)                        //만약 Timer의 수치가 0 이하로 내려갈 경우 (1초마다 동작되는 행동을 만들 때)
        {
            Timer = 1;

            GameObject Temp = Instantiate(EnemyObject);
            Temp.transform.position = new Vector3(Random.Range(-8, 8), Random.Range(-4, 4), 0);
        }

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider != null)
                {
                    hit.collider.gameObject.GetComponent<Enemy>().CharacterHit(30);
                }
            }
        }
    }
}
