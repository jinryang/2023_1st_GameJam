using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusinMove : MonoBehaviour
{
    [SerializeField] GameObject SoundWaveR;
    [SerializeField] GameObject SoundWaveL;
    [SerializeField] GameObject CircleWave;
    [SerializeField] Sprite state;
    [SerializeField] Sprite CircleSpr;
    SpriteRenderer spriteRenderer;
    Transform target;
    public string name;
    public int maxHp;
    public int HP;
    public int ATK;
    public int EXP;
    public int moveNumber = 2;
    int tempNumber;
    public int SoundWave_Count;
    int tempSoundWave;

    public float CircleFirstWait;

    private float tempFirstWait;

    public float circleWaitTime;

    private float tempCircle;

    bool IsLeft;

    public float moveTime;
    float tempMove;
    bool isMoving;

    float shotTime = 0f;
    int tempCircleNum;

    public float movingTime;
    float tempMoving;

    private Rigidbody2D rigidbody2D;
    public float Speed;
    Vector3 dir;
    int Ranx, Rany;
    public int circleNum;
    int patturn;

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        tempMove = moveTime;
        tempMoving = movingTime;
        tempNumber = moveNumber;

        tempCircleNum = circleNum;
        tempSoundWave = SoundWave_Count;
        tempCircle = circleWaitTime;
        tempFirstWait = CircleFirstWait;
        patturn = Random.Range(0, 5);
    }
    void Update()
    {
        if(patturn < 4)
        {
            spriteRenderer.sprite = state;
            if (transform.position.x - target.transform.position.x > 0)
            {
                IsLeft = true;
            }
            else
            {
                IsLeft = false;
            }
            if (moveNumber > 0)
            {
                if (!isMoving)
                {
                    moveTime -= Time.deltaTime;
                    Ranx = GetRand();
                    Rany = GetRand();
                    if (spriteRenderer.color.a < 1)
                        spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a + Time.deltaTime);

                    //스킬 소환
                }

                if (moveTime < 0)
                {
                    moveTime = tempMove;
                    isMoving = true;
                    dir = target.position - transform.position;
                    moveNumber--;
                    patturn = Random.Range(0, 5);
                }

                if (movingTime < 0)//움직임 상태가 끝났다면
                {
                    isMoving = false;
                    movingTime = tempMoving;
                    rigidbody2D.velocity = new Vector2(0, 0);
                }

                if (isMoving)//움직이기 시작함
                {
                    movingTime -= Time.deltaTime;

                    float x = Ranx * Speed;
                    float y = Rany * Speed;

                    rigidbody2D.velocity = new Vector2(x, y);
                    if (spriteRenderer.color.a > 0)
                        spriteRenderer.color = new Color(1, 1, 1, spriteRenderer.color.a - Time.deltaTime);
                }
            }
            else if (moveNumber <= 0)
            {
                if (SoundWave_Count > 0)
                {

                    Debug.Log(Quaternion.LookRotation(dir.normalized));
                    shotTime -= Time.deltaTime;
                    if (shotTime < 0)
                    {
                        shotTime = 0.25f;
                        if (IsLeft)
                        {
                            Instantiate(SoundWaveL, gameObject.transform.position, Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.forward));
                        }
                        else
                        {
                            Instantiate(SoundWaveR, gameObject.transform.position, Quaternion.AngleAxis(Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg, Vector3.forward));
                        }
                        SoundWave_Count--;
                    }
                }
                else
                {
                    moveNumber = tempNumber;
                    SoundWave_Count = tempSoundWave;
                }
            }
        }
        else if(patturn == 4)
        {
            if(CircleFirstWait > 0)
            {
                spriteRenderer.sprite = CircleSpr;
                CircleFirstWait -= Time.deltaTime;
            }
            else
            {
                if(circleWaitTime > 0)
                {
                    circleWaitTime -= Time.deltaTime;
                }
                else
                {
                    Instantiate(CircleWave, gameObject.transform.position, Quaternion.identity);
                    circleWaitTime = tempCircle;
                    circleNum--;
                }
                if(circleNum < 0)
                {
                    circleNum = tempCircleNum;
                    circleWaitTime = tempCircle;
                    CircleFirstWait = tempFirstWait;
                    patturn = Random.Range(0, 5);
                }
            }
        }
        
    }

    int GetRand()
    {
        return Random.Range(-1, 2);
    }
}
