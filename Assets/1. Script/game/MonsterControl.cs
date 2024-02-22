using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterControl : MonoBehaviour
{
    GameObject _characterObject;
    Vector3 _characterDestination;
    float _speed = 0.8f;

    [SerializeField] Transform _monsterImg;
    static SpriteRenderer _spriteRenderer;
    // Start is called before the first frame update
    void Start()
    {
        _characterObject = GameObject.FindWithTag("Character");
        _spriteRenderer = _monsterImg.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_characterObject);
        Vector3 vTargetPos = _characterObject.transform.position;
        Vector3 vPos = transform.position;
        Vector3 vDist = vTargetPos - vPos;
        Vector3 vDir = vDist.normalized;
        float fDist = vDist.magnitude;
        if (fDist > _speed * Time.deltaTime)
            transform.position += vDir * _speed * Time.deltaTime;

        if (vTargetPos.x > vPos.x)
        {
            // 마우스가 오브젝트의 오른쪽에 있을 경우
            _spriteRenderer.flipX = false; // flip을 해제합니다.
        }
        else
        {
            // 마우스가 오브젝트의 왼쪽에 있을 경우
            _spriteRenderer.flipX = true; // x축을 flip합니다.
        }
    }
}
