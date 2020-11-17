public class CharacterList : DataList<CharacterButton, CharacterData>
{
    protected override int CompareData(CharacterData a, CharacterData b)
    {
        return a.ForwardSpeed.CompareTo(b.ForwardSpeed);
    }
}
