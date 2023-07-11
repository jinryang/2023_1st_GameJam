using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;      // 캐릭터 움직임 스피드
    public Camera mainCamera; // 메인 카메라
    bool PlayerIsMoving = false;
    public Vector3 mousePosition;
    // Start is called before the first frame update
    void Start()
    {
        speed = 4.0f;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            mousePosition = Input.mousePosition;
            mousePosition = mainCamera.ScreenToWorldPoint(mousePosition);

            RaycastHit2D hit = Physics2D.Raycast(mousePosition, transform.forward, 15);
            if (hit.collider != null)
            {
                gameObject.transform.position = hit.point;
            }
        }
    }
}
