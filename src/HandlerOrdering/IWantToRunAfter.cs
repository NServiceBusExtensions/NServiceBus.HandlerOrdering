namespace HandlerOrdering;

/// <summary>
/// Used to make a Handler run after another handler as defined by <typeparamref name="THandler"/>.
/// </summary>
/// <typeparam name="THandler">The handler you want to run after.</typeparam>
public interface IWantToRunAfter<THandler>
{
}