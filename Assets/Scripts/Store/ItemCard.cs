using Neisum.ScriptableEvents;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCard : ItemSpawnable<CosmeticData>
{
    [SerializeField] GameObject coinImage;
    [SerializeField] TextMeshProUGUI coinText;
    [SerializeField] Image image;
    [SerializeField] GameObject itemBuyedImage;
    [SerializeField] SelectItemCardEvent selectItemCard;

    private void Start()
    {
        SetImage();
        SetPrice();
    }

    public void SetImage()
    {
        if (data.image != null)
            image.sprite = data.image;
    }

    public void SetPrice()
    {
        coinText.text = data.price.ToString();
    }

    public void SelectItem()
    {
        selectItemCard.Raise(this);
    }

    public void Buyed(bool active)
    {
        coinText.gameObject.SetActive(!active);
        coinImage.gameObject.SetActive(!active);
        itemBuyedImage.gameObject.SetActive(active);
    }
}
