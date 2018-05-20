using UnityEngine;
using System.Collections.Generic;

public class QuestManager : MonoBehaviour
{
    private Dictionary<string, Sprite> _iconDict;

    [SerializeField]
    private Sprite[] _icons;

    [SerializeField]
    private GameObject _questDialog;

    void Start()
    {
        _questDialog.SetActive(false);
        LoadIconsFromSprites();
    }

    private void LoadIconsFromSprites()
    {
        _iconDict = new Dictionary<string, Sprite>();
        foreach (Sprite sprite in _icons)
        {
            _iconDict.Add(sprite.name, sprite);
        }
    }
    
    /**
     * Triggers the start of a quest
     * questFilePath: supply file path to the xml file
     **/
    public void StartQuest(string questFilePath)
    {
        _questDialog.SetActive(true);
        _questDialog.GetComponent<QuestDisplayComponent>()
            .Initialize(Quest.LoadQuest(questFilePath));      //Uses the Dialog UI and initializes the quest onto the display
    }

    public Sprite GetIcon(string iconName)
    {
        if (_iconDict[iconName] != null)
            return _iconDict[iconName];
        else
            return null;
    }
}