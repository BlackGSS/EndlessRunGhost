using System.Numerics;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class CreditsModal : Modal, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI textT;
    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(textT, new UnityEngine.Vector3(eventData.position.x, eventData.position.y, 0), null);
        if (linkIndex != -1)
        { // was a link clicked?
            TMP_LinkInfo linkInfo = textT.textInfo.linkInfo[linkIndex];

            // open the link id as a url, which is the metadata we added in the text field
            Application.OpenURL(linkInfo.GetLinkID());
        }
    }

    public void ShowModal()
    {
        Show();
    }
}