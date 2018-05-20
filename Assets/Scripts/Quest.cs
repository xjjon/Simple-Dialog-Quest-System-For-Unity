using System.Collections.Generic;
using System.Xml.Serialization;
using System.IO;

public class Quest
{
    [XmlArray("Nodes")] [XmlArrayItem("Node")]
    public List<QuestNode> Nodes;

    [XmlAttribute("QuestTitle")]
    public string QuestTitle;

    [System.NonSerialized()]
    private QuestNode _currentNode;

    [System.NonSerialized]
    private int _position;

    /**
     * Returns the current node progress in quest and the moves to next node if possible.
     **/
    public QuestNode ProgressQuest()
    {
        if (HasNextQuestNode())
        {
            _currentNode = Nodes[_position++];
            return _currentNode;
        }
        return null;
    }

    private bool HasNextQuestNode()
    {
        return Nodes != null && _position < Nodes.Count;
    }

    /**
     * Loads quest from XML file.
     **/
    public static Quest LoadQuest(string fileName)
    {
        var serializer = new XmlSerializer(typeof(Quest));
        var stream = new FileStream(fileName, FileMode.Open);
        var quest = serializer.Deserialize(stream) as Quest;
        stream.Close();

        return quest;
    }
}