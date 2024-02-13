using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public CharacterManager _characterManager;

    private void Awake()
    {
        _instance = this;
    }
}
