using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControll : MonoBehaviour
{
    static float _speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static void characterInit()
    {
        _speed = 0.01f;
    }

    public void Update()
    {
        if (Input.GetKey(KeyCode.D)) { transform.Translate(Vector2.right * _speed); }
        if (Input.GetKey(KeyCode.A)) { transform.Translate(-Vector2.right * _speed); }
        if (Input.GetKey(KeyCode.W)) { transform.Translate(Vector2.up * _speed); }
        if (Input.GetKey(KeyCode.S)) { transform.Translate(-Vector2.up * _speed); }
    }
}
