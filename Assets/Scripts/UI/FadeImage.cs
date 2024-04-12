public class FadeImage : CanvasGroupView
{
    public static FadeImage Instance;

    protected override void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

        base.Awake();
    }
}