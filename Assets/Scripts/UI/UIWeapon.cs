
using UnityEngine;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour
{
    [SerializeField] public GameObject activeBackground;

    [SerializeField] public Image cooldownReady;// why not see
    [SerializeField] public Image weaponImage;


    // Start is called before the first frame update


    public void CooldownFill(float fillFraction)
    {
        cooldownReady.fillAmount = fillFraction;
    }
    public void WeaponSetColor(Color inputColor) 
    {
        weaponImage.color = inputColor;
    }
}
