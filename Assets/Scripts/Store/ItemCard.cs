using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCard : ItemSpawnable<CosmeticData>
{
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] Image image;

    //TODO: ScriptableEvent when a card is clicked

    public void SetImage()
    {
        if (data.image != null)
            image.sprite = data.image;
    }

    public void SetPrice()
    {
        coinText.text = data.price.ToString();
    }
}
