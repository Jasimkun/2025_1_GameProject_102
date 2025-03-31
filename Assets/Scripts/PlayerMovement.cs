using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f;          //�̵� �ӵ� ���� ����
    public float jumpForce = 5.0f;

    public bool isGrounded = true;

    public int coinCount = 0;
    public int totalCoins = 5;

    public Rigidbody rb;                  //�÷��̾� ��ü�� ����
 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //������ �Է�
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVeritical = Input.GetAxis("Vertical");

        //�ӵ������� ���� �̵�
        rb.velocity = new Vector3(moveHorizontal * moveSpeed, rb.velocity.y, moveVeritical * moveSpeed);

        //���� �Է�
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }
    void OnCollisionEnter(Collision collision)          //�浹�� �Ͼ�� �� ȣ��Ǵ� �Լ�
    {
        if (collision.gameObject.tag == "Ground")           //�浹�� �Ͼ ��ü�� tag�� Ground
        {
            isGrounded = true;             
        }
    }
    void OnTriggerEnter(Collider other)                //Ʈ���� ���� �ȿ� ���Դٸ� �����ϴ� �Լ�
    {
        if (other.CompareTag("Coin"))
        {
            coinCount++;
            Destroy(other.gameObject);
            Debug.Log($"���� ���� : {coinCount}/{totalCoins}");
        }

        if (other.CompareTag("Door") && coinCount >= totalCoins)
        {
            Debug.Log("���� Ŭ����");
        }
    }
}
