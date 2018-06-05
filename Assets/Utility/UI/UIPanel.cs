using System;
using UnityEngine;

public abstract class UIPanel : MonoBehaviour
{
    public event Action OnClose = delegate { };

    public virtual void Close()
    {
        OnClose();

        Destroy(gameObject);
    }

    public void OnCloseButtonPress()
    {
        Close();
    }
}
