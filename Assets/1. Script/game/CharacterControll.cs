using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    [SerializeField] Transform _characterImg;
    [SerializeField] GameObject prefabToSpawn;
    static float _speed;
    static bool _startGame = false;
    public float spawnDistance = 1f;
    static SpriteRenderer _spriteRenderer;


    void Start()
    {
        //characterInit();
    }

    public void characterInit()
    {
        init();
    }

    public void init()
    {
        _speed = 1f;
        Debug.Log(_characterImg);
        
        _spriteRenderer = _characterImg.GetComponent<SpriteRenderer>();
        _startGame = true;
    }

    public void Update()
    {
        if (_startGame)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // 오브젝트의 위치와 마우스 위치를 비교하여 x축을 flip합니다.
            if (mousePosition.x > transform.position.x)
            {
                // 마우스가 오브젝트의 오른쪽에 있을 경우
                _spriteRenderer.flipX = false; // flip을 해제합니다.
            }
            else
            {
                // 마우스가 오브젝트의 왼쪽에 있을 경우
                _spriteRenderer.flipX = true; // x축을 flip합니다.
            }

            if (Input.GetKey(KeyCode.D)) { transform.Translate(Vector2.right * Time.deltaTime * _speed); }
            if (Input.GetKey(KeyCode.A)) { transform.Translate(-Vector2.right * Time.deltaTime * _speed); }
            if (Input.GetKey(KeyCode.W)) { transform.Translate(Vector2.up * Time.deltaTime * _speed); }
            if (Input.GetKey(KeyCode.S)) { transform.Translate(-Vector2.up * Time.deltaTime * _speed); }

            if (Input.GetMouseButtonDown(0))
            {
                ClickAttack(mousePosition);
            }
        }
    }

    private void ClickAttack(Vector3 mousePosition)
    {
        // 마우스 포인터의 현재 위치를 가져오기
        mousePosition.z = 0f;  // z 축을 0으로 설정 (2D 공간을 가정)

        // 오브젝트에서 마우스 포인터 방향 계산
        Vector3 direction = mousePosition - transform.position;
        direction.Normalize();  // 방향을 단위 벡터로 정규화

        // 새로운 오브젝트를 생성하고 특정 거리에 위치하도록 조절
        Vector3 spawnPosition = transform.position + direction * spawnDistance;
        spawnPosition.z = 10f;
        Quaternion spawnRotation = Quaternion.Euler(0f, 0f, Mathf.Atan2(-direction.y, -direction.x) * Mathf.Rad2Deg);

        // 새로운 오브젝트 생성
        GameObject newObject = Instantiate(prefabToSpawn, spawnPosition, spawnRotation);
    }
}