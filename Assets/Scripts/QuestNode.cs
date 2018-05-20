using System.Xml.Serialization;

public class QuestNode
{
    [XmlElementAttribute("NodeTitle")]
    public string NodeTitle;

    [XmlElementAttribute("NodeText")]
    public string NodeText;

    [XmlElementAttribute("NodeImage")]
    public string NodeImage;

    public override string ToString()
    {
        return string.Format("[NodeTitle: {0} NodeText: {1} NodeImage: {2}",
            NodeTitle, NodeText, NodeImage);
    }
}