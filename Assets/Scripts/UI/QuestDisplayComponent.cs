using UnityEngine;
using UnityEngine.UI;

public class QuestDisplayComponent : MonoBehaviour
{
    public Quest Quest;

    [SerializeField]
    private Image _nodeImage;
    [SerializeField]
    private Text _nodeTitle;
    [SerializeField]
    private Text _nodeText;
    [SerializeField]
    private QuestManager _questManager;

    private QuestNode _currentNode;

    public void Initialize(Quest quest)
    {
        Quest = quest;
        ProgressNode();
    }

    public void ProgressNode()
    {
        _currentNode = Quest.ProgressQuest();

        if (_currentNode == null)
        {
            gameObject.SetActive(false);
            return;
        }

        _nodeImage.sprite = _questManager.GetIcon(_currentNode.NodeImage);

        _nodeTitle.text = _currentNode.NodeTitle;
        _nodeText.text = _currentNode.NodeText;

        if (_nodeImage.sprite == null)
            _nodeImage.gameObject.SetActive(false);

    }
}