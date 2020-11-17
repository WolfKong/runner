public class LevelList : DataList<LevelButton, LevelData>
{
    protected override int CompareData(LevelData a, LevelData b)
    {
        return a.TargetScore.CompareTo(b.TargetScore);
    }
}
