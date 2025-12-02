using UnityEngine;

public class InteractableResource : MonoBehaviour
{
    [Header("Tool Requirement")]
    public ToolType requiredTool = ToolType.Axe;

    [Header("Message")]
    [TextArea]
    public string successMessage = "เก็บทรัพยากรเรียบร้อย!";
    [TextArea]
    public string failMessage = "ต้องใช้อุปกรณ์ให้เหมาะสมก่อนนะ";

    public bool TryHarvest(ToolType playerTool)
    {
        if (playerTool == requiredTool)
        {
            Debug.Log("Harvest success: " + gameObject.name);
            Destroy(gameObject);     // ลบวัตถุออกจากฉาก
            return true;
        }
        else
        {
            Debug.Log("Wrong tool. Need: " + requiredTool);
            return false;
        }
    }
}
