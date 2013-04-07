using HandlerOrdering;
using Scalpel;


[Remove]
public class Sample
{

    public class Handler1 : IWantToRunAfter<Handler3>
    {
    }

    public class Handler2 : IWantToRunAfter<Handler1>, IWantToRunAfter<Handler3>
    {
    }

    public class Handler3
    {
    }

}