using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    public GameController gameController;
    public int towerIndex; // 这个按钮对应的塔的索引
    public Transform modelHand; // 模型手的Transform

    public float activationDistance = 0.1f; // 定义按钮激活的距离阈值

    void Start()
    {
        // 获取按钮组件并添加点击事件监听器
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }
    }

    void Update()
    {
        // 在每帧中检测按钮和模型手的距离
        if (IsButtonNearModelHand())
        {
            // 如果按钮接近模型手，可以改变按钮的颜色或执行其他操作
            // 示例：改变按钮的颜色为红色
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            // 如果按钮不接近模型手，可以恢复按钮的颜色
            // 示例：恢复按钮的颜色为默认颜色
            GetComponent<Image>().color = Color.white;
        }
    }

    bool IsButtonNearModelHand()
    {
        // 获取按钮的位置和模型手的位置
        Vector3 buttonPosition = transform.position;
        Vector3 handPosition = modelHand.position;

        // 计算按钮和模型手之间的距离
        float distance = Vector3.Distance(buttonPosition, handPosition);

        // 检查距离是否小于激活距离阈值
        return distance < activationDistance;
    }

    void OnButtonClicked()
    {
        // 当按钮被点击时，通知游戏控制器
        gameController.OnTowerButtonClicked(towerIndex);
    }
}