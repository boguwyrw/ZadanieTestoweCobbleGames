public struct CharacterCoord
{
    public float CoordX;
    public float CoordZ;
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
