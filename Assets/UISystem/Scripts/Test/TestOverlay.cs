using System.Collections;
using System.Collections.Generic;
using ModulerUISystem;
using UnityEngine;

public class TestOverlay : MonoBehaviour
{
    public ViewConfig overlay;
    public ViewConfig view;
    [ContextMenu("ShowOverlay")]
    public void ShowOverlay()
    {
       ModulerUISystem.UIManager.instance.ShowOverlay(overlay);
    }
    
    [ContextMenu("HideOverlay")]
    public void HideOverlay()
    {
        ModulerUISystem.UIManager.instance.HideOverlay(overlay);        
    }
    [ContextMenu("ShowView")]
    public void ShowView()
    {
        ModulerUISystem.UIManager.instance.ShowView(view);
    }
}
