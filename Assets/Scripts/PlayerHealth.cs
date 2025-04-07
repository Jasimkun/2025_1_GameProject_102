using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;         //최대 생명력
    public int currentLives = 1;     //현재 생명력

    public float invincibleTime = 1.0f;   //피격 후 무적 시간 
    public bool isinvincible = false;     //무적 여부의 값 

    // Start is called before the first frame update
    void Start()
    {
        currentLives = maxLives;         //생명력 초기화
    }
    void OnTriggerEnter(Collider other)         //트리거 영역 안에 들어왔다를 감시하는 함수
    {
        if (other.CompareTag("Missile"))
        {
            currentLives--;                 //미사일과 충돌 시 1씩 생명력을 제거한다.
            Destroy(other.gameObject);      //미사일 오브젝트를 제거한다.

            if (currentLives <= 0)        //지금 체력이 0 이하일 경우
            { 
                GameOver();              //게임 오버 함수 처리
            }
        }
    }

   public void GameOver()      //게임 오버 처리
    {
        gameObject.SetActive(false);    //플레이어 비활성화
        Invoke("RestartGame", 3.0f);    //3초 후 현재 씬 재시작
    }

    public void RestartGame()
    {
        SceneManager. LoadScene(SceneManager.GetActiveScene().name);  //현재 씬 재시작
    }
}
