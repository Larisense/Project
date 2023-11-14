using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour
{
    public GameController gameController;
    public int towerIndex; // �����ť��Ӧ����������
    public Transform modelHand; // ģ���ֵ�Transform

    public float activationDistance = 0.1f; // ���尴ť����ľ�����ֵ

    void Start()
    {
        // ��ȡ��ť�������ӵ���¼�������
        Button button = GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(OnButtonClicked);
        }
    }

    void Update()
    {
        // ��ÿ֡�м�ⰴť��ģ���ֵľ���
        if (IsButtonNearModelHand())
        {
            // �����ť�ӽ�ģ���֣����Ըı䰴ť����ɫ��ִ����������
            // ʾ�����ı䰴ť����ɫΪ��ɫ
            GetComponent<Image>().color = Color.red;
        }
        else
        {
            // �����ť���ӽ�ģ���֣����Իָ���ť����ɫ
            // ʾ�����ָ���ť����ɫΪĬ����ɫ
            GetComponent<Image>().color = Color.white;
        }
    }

    bool IsButtonNearModelHand()
    {
        // ��ȡ��ť��λ�ú�ģ���ֵ�λ��
        Vector3 buttonPosition = transform.position;
        Vector3 handPosition = modelHand.position;

        // ���㰴ť��ģ����֮��ľ���
        float distance = Vector3.Distance(buttonPosition, handPosition);

        // �������Ƿ�С�ڼ��������ֵ
        return distance < activationDistance;
    }

    void OnButtonClicked()
    {
        // ����ť�����ʱ��֪ͨ��Ϸ������
        gameController.OnTowerButtonClicked(towerIndex);
    }
}