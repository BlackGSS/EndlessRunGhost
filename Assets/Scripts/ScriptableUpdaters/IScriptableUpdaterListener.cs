namespace Neisum.ScriptableUpdaters
{
    public interface IScriptableUpdaterListener<T>
    {
        public void ScriptableResponse(T data);
    }
}