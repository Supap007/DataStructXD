using UnityEngine;
using TMPro;

public class PlayerEquipment : MonoBehaviour
{
    [Header("Starting Tools")]
    public ToolType[] startingTools = new ToolType[3]
    {
        ToolType.Axe,
        ToolType.Shovel,
        ToolType.Sword
    };

    [Header("UI")]
    public TMP_Text toolText;

    [Header("Current Tool")]
    public ToolType currentTool = ToolType.None;

    int currentIndex = 0;

    void Start()
    {
        if (startingTools.Length > 0)
        {
            currentIndex = 0;
            currentTool = startingTools[0];
        }

        UpdateToolUI();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) EquipIndex(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) EquipIndex(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) EquipIndex(2);
    }

    void EquipIndex(int index)
    {
        if (index < 0 || index >= startingTools.Length) return;

        currentIndex = index;
        currentTool = startingTools[index];

        UpdateToolUI();
    }

    void UpdateToolUI()
    {
        if (toolText != null)
        {
            toolText.text = "Your tool : " + currentTool.ToString();
        }
    }
}
