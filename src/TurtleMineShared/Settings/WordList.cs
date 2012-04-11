using System.Collections.Generic;

namespace TurtleMine.Settings
{
	/// <summary>Describes a list of word</summary>
	[System.SerializableAttribute]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class WordList : List<string>
	{
		public static List<string> DefaultWords()
		{
			var list = new List<string> {string.Empty, Resources.Strings.IssueText, Resources.Strings.RefsText};

		    return list;
		}
	}

}