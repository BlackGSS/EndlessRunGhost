namespace Neisum.ScriptableEvents
{
    public interface IScriptableEventListener<T>
    {
        public void ScriptableResponse(T data);
    }
}