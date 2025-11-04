using UnityEngine;

public interface HealthBarsUI
{
    public RectTransform rectTransform { get; set; }
    public GameObject healthBarsFill { get; set; }
    public GameObject healthBarsBG { get; set; }
    public GameObject characterObject { get; set; }
    public void updateHealthBars();
}
