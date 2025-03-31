using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;          //이동 속도 변수 설정
    public float jumpForce = 5.0f;

    public bool isGrounded = true;

    public int coinCount = 0;
    public int totalCoins = 5;

    public Rigidbody rb;                  //플레이어 강체를 선언
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //움직임 입력
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVeritical = Input.GetAxis("Vertical");

        //속도값으로 직접 이동
        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVeritical * moveSpeed);

        //점프 입력
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)          //충돌이 일어났을 때 호출되는 함수
    {
        if (collision.gameObject.tag == "Ground")           //충돌이 일어난 물체의 tag가 Ground
        {
            isGrounded = true;             
        }
    }
    void OnTriggerEnter(Collider other)                //트리거 영역 안에 들어왔다를 감시하는 함수
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            Debug.Log($"코인 수집 : {coinCount}/{totalCoins}");
        }

        if (other.CompareTag("Door") && coinCount >= totalCoins)
        {
            Debug.Log("게임 클리어");
        }
    }
}
