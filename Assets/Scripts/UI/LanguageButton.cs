using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Localization.Settings;

public class LanguageButton : MonoBehaviour
{    
    [SerializeField] Image languageImage;
    [SerializeField] Sprite spanishSprite;
    [SerializeField] Sprite englishSprite;

    private int localeIndex;
    
    void Start()
    {
        SetLanguageImage();
        if (LocalizationSettings.SelectedLocale.name.Contains("Spanish"))
            localeIndex = 1;
        else
            localeIndex = 0;
    }
    
    public void OnNextLocaleShowed()
    {
        localeIndex = localeIndex + 1 >= LocalizationSettings.AvailableLocales.Locales.Count ? 0 : localeIndex + 1;
        LocalizationSettings.SelectedLocale = LocalizationSettings.AvailableLocales.Locales[localeIndex];
        SetLanguageImage();
    }

    private void SetLanguageImage()
    {
        if (LocalizationSettings.SelectedLocale.name.Contains("Spanish"))
            languageImage.sprite = spanishSprite;
        else
            languageImage.sprite = englishSprite;
    }
}
