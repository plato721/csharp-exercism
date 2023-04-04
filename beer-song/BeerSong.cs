public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        var nextTakeDown = takeDown - 1;

        IBottleHelper bottleHelper = GetBottleHelper(startBottles);
        var nextBottleNumber = bottleHelper.NextBottleHelper();

        return $"{bottleHelper.FirstBottlePhrase()} of beer on the wall, {bottleHelper.SecondBottlePhrase()} of beer.\n" +
            $"{bottleHelper.Directive()}, {nextBottleNumber.SecondBottlePhrase()} of beer on the wall." +
            (nextTakeDown > 0
                ? "\n\n" + Recite(nextBottleNumber.StartBottles(), nextTakeDown)
                : "");
    }

    private static IBottleHelper GetBottleHelper(int numBottles) =>
        numBottles switch
        {
            1 => new SingleBottleHelper(),
            0 => new ZeroBottleHelper(),
            _ => new StandardBottleHelper(numBottles),
        };
}

public interface IBottleHelper
{
    public int StartBottles();

    public string FirstBottlePhrase();

    public string SecondBottlePhrase();

    public string Directive();

    public IBottleHelper NextBottleHelper();
}

public class ZeroBottleHelper : IBottleHelper
{
    public int StartBottles() => 0;

    public string FirstBottlePhrase() => "No more bottles";

    public string SecondBottlePhrase() => "no more bottles";

    public string Directive() => "Go to the store and buy some more";

    public IBottleHelper NextBottleHelper() => new StandardBottleHelper(99);
}

public class SingleBottleHelper : IBottleHelper
{
    public int StartBottles() => 1;

    public string FirstBottlePhrase() => "1 bottle";

    public string SecondBottlePhrase() => "1 bottle";

    public string Directive() => "Take it down and pass it around";

    public IBottleHelper NextBottleHelper() => new ZeroBottleHelper();
}

public class StandardBottleHelper : IBottleHelper
{
    private readonly int _startBottles;

    public StandardBottleHelper(int startBottles) => _startBottles = startBottles;

    public int StartBottles() => _startBottles;

    public string FirstBottlePhrase() => $"{_startBottles} bottles";

    public string SecondBottlePhrase() => $"{_startBottles} bottles";

    public string Directive() =>$"Take one down and pass it around";

    public IBottleHelper NextBottleHelper()
    {
        var nextStartBottles = _startBottles - 1;
        return nextStartBottles == 1
            ? new SingleBottleHelper()
            : new StandardBottleHelper(nextStartBottles);
    }
}
