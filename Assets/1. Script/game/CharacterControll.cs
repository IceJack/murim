using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    [SerializeField] Transform _characterImg;
    static float _speed;
    static bool _startGame = false;
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
        }
    }
}