namespace HarryPotter.Games.Core;
public abstract class AbstractGameCommand
{
    public virtual void Execute () => throw new NotImplementedException();
    public virtual void Execute (Game item) => throw new NotImplementedException();
}
