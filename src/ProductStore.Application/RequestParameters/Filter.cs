namespace ProductStore.Application.RequestParams;
public class Filter<T>
{
    public string Key { get; set; }
    public T Value { get; set; }
}