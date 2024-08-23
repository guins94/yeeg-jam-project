using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUIController : UIGenericController
{
    override protected void ListenForUIChange()
    {
        GlobalActions.CoinAmountChanged += UpdateUI;
    }
}
