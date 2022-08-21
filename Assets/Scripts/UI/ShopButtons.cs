using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButtons : MonoBehaviour
{
    [SerializeField] GameObject _txtAction;

    public void BuyEquip(int a)
    {

        ShowInfoUI(true, "PLEASE COME BACK WHEN YOU CAN AFFORD IT!");
    }

    public void ShowInfoUI(bool show, string txt)
    {
        _txtAction.SetActive(show);

        _txtAction.GetComponentInChildren<TMPro.TMP_Text>().text = txt;
    }
}
