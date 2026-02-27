using UnityEngine;
using UnityEngine.UI;

public class BackGroundScroll : MonoBehaviour
{
    [SerializeField] RawImage BackGround;
    [SerializeField] float ScrollX;
    [SerializeField] float ScrollY;

    // Update is called once per frame
    void Update()
    {
        BackGround.uvRect = new Rect(BackGround.uvRect.position + new Vector2(ScrollX, ScrollY) * Time.deltaTime, BackGround.uvRect.size);
    }
}
