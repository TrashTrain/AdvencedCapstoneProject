
public class PlayerTest
{
    private int boundaryLevel = 0;

    public int GetBoundaryLevel()
    {
        return boundaryLevel;
    }

    public void SetBoundaryLevel(int level)
    {
        boundaryLevel = level;
    }

    public void SetUpBoundaryLevel()
    {
        boundaryLevel += 1;
    }

    public void SetDownBoundaryLevel()
    {
        boundaryLevel -= 1;
    }

}
