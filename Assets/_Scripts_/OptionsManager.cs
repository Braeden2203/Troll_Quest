using UnityEngine;

public class OptionsManager : MonoBehaviour
{
    Animator UIBookAnimator;


    private void Start()
    {
        UIBookAnimator = GetComponent<Animator>();
    }
    public void OnOptionsClick()
    {
        UIBookAnimator.SetTrigger("OnOptionsOpen");
    }


    public void OnOptionsCloseClick()
    {
        UIBookAnimator.SetTrigger("OnBookClose");
    }
}
