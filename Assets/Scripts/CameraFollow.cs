using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;    //따라갈 대상 (플레이어)
    public Vector3 offset = new Vector3(0, 5, -10);  //플레이어로부터의 거리
    public float smoothSpeed = 0.125f;               //따라가는 속도

    private void LateUpdate()                        //카메라 움직임은 보통 LateUpdate에서 처리
    {
        //LateUpdate 를 사용하는 이유는 카메라가 플레이어의 이동을 모두 처리한 이후에 따라가게 하기 위해
        Vector3 desiredPosition = target.position + offset;     //카메라 위치 설정
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);  //따라갈 위치 설정
        transform.position = smoothPosition;                                                      //지금 오브젝트 위치를 잡아준다

        transform.LookAt(target.position);                                                     //카메라가 항상 플레이어를 바라보도록 설정
    }
}
