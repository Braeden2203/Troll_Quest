using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    Animator UIBookAnimator;

    [SerializeField] Canvas OptionsMenu;
    [SerializeField] Canvas MainMenuInputs;
    

    private void Start()
    {
        UIBookAnimator = GetComponent<Animator>();
        
    }
    public void OnOptionsClick()
    {
        MainMenuInputs.gameObject.SetActive(false);
        UIBookAnimator.SetTrigger("OnOptionsOpen");
    }
    public void OnOptionsOpenAnimFinish()
    {
        OptionsMenu.gameObject.SetActive(true);
        
    }

    public void OnOptionsCloseClick()
    {
        OptionsMenu.gameObject.SetActive(false);
        UIBookAnimator.SetTrigger("OnBookClose");
        
    }

    public void OnOptionsCloseAnimFinish()
    {
        MainMenuInputs.gameObject.SetActive(true);
    }
}
