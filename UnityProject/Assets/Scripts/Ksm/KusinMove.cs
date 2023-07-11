using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KusinMove : MonoBehaviour
{
    [SerializeField] GameObject SoundWaveR;
    [SerializeField] GameObject SoundWaveL;
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

    bool IsLeft;

    public float moveTime;
    float tempMove;
    bool isMoving;

    float shotTime = 0f;

    public float movingTime;
    float tempMoving;

    private Rigidbody2D rigidbody2D;
    public float Speed;
    Vector3 dir;
    int Ranx, Rany;

    void Start()
    {
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        tempMove = moveTime;
        tempMoving = movingTime;
        tempNumber = moveNumber;
        tempSoundWave = SoundWave_Count;
    }
    void Update()
    {
        if (transform.position.x - target.transform.position.x > 0)
        {
            IsLeft = true;
        }
        else
        {
            IsLeft = false;
        }
        if(moveNumber > 0)
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

            if(moveTime < 0)
            {
                moveTime = tempMove;
                isMoving = true;
                dir = target.position - transform.position;
                moveNumber--;
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
        else if(moveNumber <= 0)
        {
            if(SoundWave_Count > 0)
            {

                Debug.Log(Quaternion.LookRotation(dir.normalized));
                shotTime -= Time.deltaTime;
                if(shotTime < 0)
                {
                    shotTime = 0.25f;
                    if(IsLeft)
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

    int GetRand()
    {
        return Random.Range(-1, 2);
    }
}
