using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드
    public Vector2 movePoint; // 이동 위치 저장
    public Camera mainCamera; // 메인 카메라
    bool PlayerIsMoving = false;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4.0f;
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 15);
            Debug.DrawRay(mousePosition, transform.forward * 10, Color.red, 0.3f);
            if (hit.collider != null)
            {
                movePoint = hit.point;
                Debug.Log(movePoint);
                
            }
        }

        MovePlayer();


    }
    void MovePlayer()
    {
        gameObject.transform.position = Vector2.MoveTowards(transform.position, movePoint, speed*Time.deltaTime);
    }
}
