namespace Neisum.ScriptableEvents
{
    public interface IScriptableEvents<T>
    {
        void RaiseScriptableUpdatedEvent(T data);
        void AddListener(IScriptableEventListener<T> listener);
        void RemoveListener(IScriptableEventListener<T> listener);
    }
}