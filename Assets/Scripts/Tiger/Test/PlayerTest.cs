
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
        if(boundaryLevel < 3)
            boundaryLevel += 1;
    }

    public void SetDownBoundaryLevel()
    {
        if(boundaryLevel > 0)
            boundaryLevel -= 1;
    }

}
