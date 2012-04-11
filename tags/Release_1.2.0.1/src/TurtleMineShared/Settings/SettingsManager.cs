using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace TurtleMine.Settings
{
	/// <summary>TurltleMine Settings Manager</summary>
	[SerializableAttribute]
	[XmlType(AnonymousType = true)]
	[XmlRootAttribute(Namespace = "", IsNullable = false)]
	public class SettingsManager
	{
		#region Settings

		/// <summary>
		/// Save all Settings
		/// </summary>
		public static void SaveSettings()
		{
			//Create the directory if it does not exist
			var settingsDirectory = Path.GetDirectoryName(SettingsFile);
			if (settingsDirectory != null && !Directory.Exists(settingsDirectory))
			{
				Directory.CreateDirectory(settingsDirectory);
			}

			//Save the settings
			Settings.SaveToFile(SettingsFile);
		}

		/// <summary>
		/// Load all settings from settings file
		/// </summary>
		public static void LoadSettings()
		{
			if (Settings == null)
			{
				Settings = File.Exists(SettingsFile) ? LoadFromFile(SettingsFile) : new SettingsManager();    
			}
		}

		/// <summary>
		/// Gets or sets the settings.
		/// </summary>
		/// <value>The settings.</value>
		internal static SettingsManager Settings { get; set; }

		#endregion

		#region Properties

		private List<Project> _projectsField;

		private ConnectionSettings _connectivityField;

		private WordList _wordsField;

		private List<ColumnListColumn> _columnsField;

		/// <summary>List of Projects</summary>
		[XmlArrayItemAttribute(IsNullable = false)]
		public List<Project> Projects
		{
			get { return _projectsField ?? (_projectsField = new List<Project>()); }
			set { _projectsField = value; }
		}

		/// <summary>Test whether <see cref="Projects"/> should be serialized</summary>
		public virtual bool ShouldSerializeProjects()
		{
			return _projectsField != null && _projectsField.Count > 0;
		}

		/// <summary>Default Connection Settings</summary>
		public ConnectionSettings Connectivity
		{
			get { return _connectivityField ?? (_connectivityField = new ConnectionSettings()); }
			set { _connectivityField = value; }
		}

		/// <summary>Test whether <see cref="Connectivity"/> should be serialized</summary>
		public virtual bool ShouldSerializeConnectivity()
		{
			return _connectivityField != null;
		}

		/// <summary>Default word list</summary>
		[XmlArrayItemAttribute("Word", IsNullable = false)]
		public WordList Words
		{
			get { return _wordsField ?? (_wordsField = new WordList()); }
			set { _wordsField = value; }
		}

		/// <summary>Test whether <see cref="Words"/> should be serialized</summary>
		public virtual bool ShouldSerializeWords()
		{
			return _wordsField != null && _wordsField.Count > 0;
		}

		/// <summary>Default columns list</summary>
		[XmlArrayItemAttribute("Column", IsNullable = false)]
		public List<ColumnListColumn> Columns
		{
			get { return _columnsField ?? (_columnsField = new List<ColumnListColumn>()); }
			set { _columnsField = value; }
		}

		/// <summary>Test whether <see cref="Columns"/> should be serialized</summary>
		public virtual bool ShouldSerializeColumns()
		{
			return _columnsField != null && _columnsField.Count > 0;
		}

		/// <remarks/>
		public UpdateInterval Updates { get; set; }

		#endregion

		#region Serialize/Deserialize

		public static readonly string SettingsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TurtleMine\\Settings.xml");

		private static XmlSerializer _serializer;

		private static XmlSerializer Serializer
		{
			get
			{
				return _serializer ??
					   (_serializer = new XmlSerializer(typeof(SettingsManager)));
			}
		}

		/// <summary>
		/// Serializes current SettingsManager object into an XML document
		/// </summary>
		/// <returns>string XML value</returns>
		public virtual string Serialize()
		{
			StreamReader streamReader = null;
			MemoryStream memoryStream = null;
			try
			{
				memoryStream = new MemoryStream();
				Serializer.Serialize(memoryStream, this);
				memoryStream.Seek(0, SeekOrigin.Begin);
				streamReader = new StreamReader(memoryStream);
				return streamReader.ReadToEnd();
			}
			finally
			{
				if ((streamReader != null))
				{
					streamReader.Dispose();
				}
				if ((memoryStream != null))
				{
					memoryStream.Dispose();
				}
			}
		}

		/// <summary>
		/// Deserializes workflow markup into an SettingsManager object
		/// </summary>
		/// <param name="xml">string workflow markup to deserialize</param>
		/// <param name="obj">Output SettingsManager object</param>
		/// <param name="exception">output Exception value if deserialize failed</param>
		/// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
		public static bool Deserialize(string xml, out SettingsManager obj, out Exception exception)
		{
			exception = null;
			obj = default(SettingsManager);
			try
			{
				obj = Deserialize(xml);
				return true;
			}
			catch (Exception ex)
			{
				exception = ex;
				return false;
			}
		}

		public static bool Deserialize(string xml, out SettingsManager obj)
		{
			Exception exception;
			return Deserialize(xml, out obj, out exception);
		}

		public static SettingsManager Deserialize(string xml)
		{
			StringReader stringReader = null;
			try
			{
				stringReader = new StringReader(xml);
				return ((SettingsManager)(Serializer.Deserialize(System.Xml.XmlReader.Create(stringReader))));
			}
			finally
			{
				if ((stringReader != null))
				{
					stringReader.Dispose();
				}
			}
		}

		/// <summary>
		/// Serializes current SettingsManager object into file
		/// </summary>
		/// <param name="fileName">full path of outupt xml file</param>
		/// <param name="exception">output Exception value if failed</param>
		/// <returns>true if can serialize and save into file; otherwise, false</returns>
		public virtual bool SaveToFile(string fileName, out Exception exception)
		{
			exception = null;
			try
			{
				SaveToFile(fileName);
				return true;
			}
			catch (Exception e)
			{
				exception = e;
				return false;
			}
		}

		public virtual void SaveToFile(string fileName)
		{
			StreamWriter streamWriter = null;
			try
			{
				var xmlString = Serialize();
				var xmlFile = new FileInfo(fileName);
				streamWriter = xmlFile.CreateText();
				streamWriter.WriteLine(xmlString);
				streamWriter.Close();
			}
			finally
			{
				if ((streamWriter != null))
				{
					streamWriter.Dispose();
				}
			}
		}

		/// <summary>
		/// Deserializes xml markup from file into an SettingsManager object
		/// </summary>
		/// <param name="fileName">string xml file to load and deserialize</param>
		/// <param name="obj">Output SettingsManager object</param>
		/// <param name="exception">output Exception value if deserialize failed</param>
		/// <returns>true if this XmlSerializer can deserialize the object; otherwise, false</returns>
		public static bool LoadFromFile(string fileName, out SettingsManager obj, out Exception exception)
		{
			exception = null;
			obj = default(SettingsManager);
			try
			{
				obj = LoadFromFile(fileName);
				return true;
			}
			catch (Exception ex)
			{
				exception = ex;
				return false;
			}
		}

		public static bool LoadFromFile(string fileName, out SettingsManager obj)
		{
			Exception exception;
			return LoadFromFile(fileName, out obj, out exception);
		}

		public static SettingsManager LoadFromFile(string fileName)
		{
			FileStream file = null;
			StreamReader sr = null;
			try
			{
				file = new FileStream(fileName, FileMode.Open, FileAccess.Read);
				sr = new StreamReader(file);
				var xmlString = sr.ReadToEnd();
				sr.Close();
				file.Close();
				return Deserialize(xmlString);
			}
			finally
			{
				if ((file != null))
				{
					file.Dispose();
				}
				if ((sr != null))
				{
					sr.Dispose();
				}
			}
		}
		#endregion

	}
}