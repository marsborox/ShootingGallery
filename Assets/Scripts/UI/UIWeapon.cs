
using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour
{
    [SerializeField] public GameObject activeBackground;

    [SerializeField] public Image cooldownReady;// why not see
    [SerializeField] public Image weaponImage;

    [SerializeField] TextMeshProUGUI ammoText;
    // Start is called before the first frame update


    public void CooldownFill(float fillFraction)
    {
        cooldownReady.fillAmount = fillFraction;
    }
    public void WeaponSetColor(Color inputColor) 
    {
        weaponImage.color = inputColor;
    }
    public void DisplayAmmo(string ammoInsertText)
    {
        ammoText.text = ammoInsertText;
    }
}
