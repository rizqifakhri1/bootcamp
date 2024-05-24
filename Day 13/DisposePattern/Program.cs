class GameController : IDiisposable
{
    public List<int> totalPlayer;
    public List<object> allPlayer;
    public ExternalResource externalResource;

    private bool disposed = false;

    protected virtual void Dispose(bool disposing)
    {
        if (!disposed)
        {
            totalPlayer = null;
            allPlayer = null;
        }
        externalResource = null;
        disposed = true;
    }

    ~GameController()
    {
        Dispose(disposing: false);
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);

    }
}
