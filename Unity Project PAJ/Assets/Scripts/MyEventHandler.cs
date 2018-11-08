using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MyEventHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void OnPointerEnter(PointerEventData pointerEventData)
    {
        anim.SetBool("Muyr", true);  
    }

    public void OnPointerExit(PointerEventData pointerEventData)
    {
        anim.SetBool("Muyr", false);
    }
}
