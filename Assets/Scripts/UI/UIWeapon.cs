
using UnityEngine;
using UnityEngine.UI;

public class UIWeapon : MonoBehaviour
{
    [SerializeField] public GameObject activeBackground;

    [SerializeField] public Image cooldownReady;// why not see

    
    // Start is called before the first frame update


    public void CooldownFill(float fillFraction)
    {
        cooldownReady.fillAmount = fillFraction;
    }
}
