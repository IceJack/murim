using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CharacterControll charControll = gameObject.GetComponent<CharacterControll>();
        charControll.characterInit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
