namespace Neisum.ScriptableUpdaters
{
    public interface IScriptableEventListener<T>
    {
        public void ScriptableResponse(T data);
    }
}