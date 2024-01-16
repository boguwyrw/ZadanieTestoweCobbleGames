using UnityEngine;

[System.Serializable]
public struct CharacterCoord
{
    public float CoordX;
    public float CoordZ;

    public Vector3 GetCoord()
    {
        return new Vector3(CoordX, 0.0f, CoordZ);
    }
}

[System.Serializable]
public class CharacterData
{
    public CharacterCoord CharacterPosition;

    public CharacterData(Character character)
    {
        CharacterPosition.CoordX = character.transform.position.x;
        CharacterPosition.CoordZ = character.transform.position.z;
    }
}
