using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CharacterData
{
    public float[] CharacterPosition;

    public CharacterData(Character character)
    {
        CharacterPosition = new float[2];
        CharacterPosition[0] = character.transform.position.x;
        CharacterPosition[1] = character.transform.position.z;
    }
}
