using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace TRMIssues
{
    /// <summary>
    /// Manage saved application settings
    /// </summary>
    internal class SettingsManager
    {
        #region Older Settings Support

        /// <summary>
        /// Converts the old column settings from versions prior to 1.1.0.4.
        /// </summary>
        private static void convertOldColumnSettings()
        {
            //Old column settings
            const string regAdressColumns = "Software\\TortoiseSVNRedminePlugin\\Columns";
            const string regAdressColumnsHidden = "Software\\TortoiseSVNRedminePlugin\\Columns\\hidden";

            //Try and open the old column reg settings
            var myReg = openRegistryKey(regAdressColumns);

            if (myReg == null)
            {
                return;
            }

            var tempColumnsDisplay = new Dictionary<int, int>();

            //As the old settings were text based, map each text string to it's column index
            foreach (var valueName in myReg.GetValueNames())
            {
                //Can not use switch with non constant values (Resources)
                if (valueName == "  ")
                {
                    tempColumnsDisplay.Add(0, int.Parse(myReg.GetValue(valueName).ToString()));
                }
                if (valueName == Resources.FormsResources.ColumnNumber)
                {
                    tempColumnsDisplay.Add(1, int.Parse(myReg.GetValue(valueName).ToString()));
                }
                if (valueName == Resources.FormsResources.ColumnType)
                {
                    tempColumnsDisplay.Add(2, int.Parse(myReg.GetValue(valueName).ToString()));
                }
                if (valueName == Resources.FormsResources.ColumnSummary)
                {
                    tempColumnsDisplay.Add(3, int.Parse(myReg.GetValue(valueName).ToString()));
                }
                if (valueName == Resources.FormsResources.ColumnStatus)
                {
                    tempColumnsDisplay.Add(4, int.Parse(myReg.GetValue(valueName).ToString()));
                }
                if (valueName == Resources.FormsResources.ColumnAuthor)
                {
                    tempColumnsDisplay.Add(5, int.Parse(myReg.GetValue(valueName).ToString()));
                }
                if (valueName == Resources.FormsResources.ColumnLastUpdated)
                {
                    tempColumnsDisplay.Add(6, int.Parse(myReg.GetValue(valueName).ToString()));
                }
            }

            //See if we have any hidden columns
            myReg = openRegistryKey(regAdressColumnsHidden);

            if (myReg != null)
            {
                foreach (var valueName in myReg.GetValueNames())
                {
                    //If hidden key exists flag it as a negative display index to identify it as hidden but still keep it's position
                    var key = int.Parse(myReg.GetValue(valueName).ToString());
                    if (tempColumnsDisplay.ContainsKey(key))
                    {
                        tempColumnsDisplay[key] = -1*tempColumnsDisplay[key];
                    }
                }
            }

            //Now that column list is collected save it to new column list settings
            //Create / Open registry key for Column List settings
            myReg = openRegistryKey(RegAdressColumnsDisplay, true, true);

            //Make sure we got a valid key
            if (myReg == null)
            {
                return;
            }

            //Store Column Names and index
            foreach (var column in tempColumnsDisplay)
            {
                myReg.SetValue(column.Key.ToString(), column.Value);
            }

            //Delete old keys so we do not hit this code again
            Registry.CurrentUser.DeleteSubKeyTree(regAdressColumns);
        }

        /// <summary>
        /// Renames the old settings from version prior to 1.1.0.5.
        /// </summary>
        private static void renameOldSettings()
        {
            //Old Registry location
            const string regAddressOldBase = "Software\\TortoiseSVNRedminePlugin";

            //Try and open the old reg settings location
            var myReg = openRegistryKey(regAddressOldBase);

            if (myReg == null)
            {
                return;
            }

            //Create destionation key
            using (var destinationKey = openRegistryKey(RegAdressBase, true))
            {
                //Open the sourceKey we are copying from
                using (var sourceKey = openRegistryKey(regAddressOldBase))
                {
                    recursiveCopyKey(sourceKey, destinationKey);
                }
            }

            //Remove old key
            Registry.CurrentUser.DeleteSubKeyTree(regAddressOldBase);
        }

        #endregion

        #region Members

        //Registry settings
        private const string RegAdressBase = "Software\\TortoiseRedminePlugin";
        private const string RegAdressRecent = "Software\\TortoiseRedminePlugin\\RecentID";
        private const string RegAdressColumnsDisplay = "Software\\TortoiseRedminePlugin\\ColumnsDisplay";
        private const string KeyWidth = "SizeWidth";
        private const string KeyHeight = "SizeHeight";
        private const string KeyHideDescription = "HideDescription";
        private const string KeyDescriptionHeight = "DescriptionHeight";
        private const string KeySortColumn = "SortColumn";
        private const string KeySortOrder = "SortOrder";
        private const string KeyIncludeSummary = "IncludeSummary";

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the size of the form.
        /// </summary>
        /// <value>The size of the form.</value>
        public Size FormSize { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to [hide description].
        /// </summary>
        /// <value><c>true</c> if [hide description]; otherwise, <c>false</c>.</value>
        public bool HideDescription { get; set; }

        /// <summary>
        /// Gets or sets the height of the description panel.
        /// </summary>
        /// <value>The height of the description panel.</value>
        public int DescriptionHeight { get; set; }

        /// <summary>
        /// Gets or sets the sort column.
        /// </summary>
        /// <value>The sort column.</value>
        public int SortColumn { get; set; }

        /// <summary>
        /// Gets or sets the sort order.
        /// </summary>
        /// <value>The sort order.</value>
        public SortOrder SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the list of columns to display.
        /// </summary>
        /// <value>The display list of columns.</value>
        public Dictionary<int, int> ColumnsDisplay { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to [include summary].
        /// </summary>
        /// <value><c>true</c> if [include summary]; otherwise, <c>false</c>.</value>
        public bool IncludeSummary { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Loads the settings from the registry for the Form.
        /// </summary>
        public void LoadFormSettings()
        {
            //Get Size and Description window settings
            var myReg = openRegistryKey(RegAdressBase);

            //Make sure we got a valid key
            if (myReg == null)
            {
                return;
            }

            //Get Size Settings
            var width = myReg.GetValue(KeyWidth);
            var height = myReg.GetValue(KeyHeight);
            if (width != null && height != null)
            {
                FormSize = new Size((int)width, (int)height);
            }

            //Get Description window settings
            var hideDescription = myReg.GetValue(KeyHideDescription);
            HideDescription = hideDescription == null || bool.Parse(hideDescription.ToString());

            var descriptionHeight = myReg.GetValue(KeyDescriptionHeight);
            if (descriptionHeight != null)
            {
                DescriptionHeight = (int) descriptionHeight;
            }

            //Include summary in comment flag
            var includeSummary = myReg.GetValue(KeyIncludeSummary);
            if (includeSummary != null)
            {
                IncludeSummary = bool.Parse(includeSummary.ToString());
            }
        }

        /// <summary>
        /// Loads the settings from the registry for the List Display.
        /// </summary>
        public void LoadListSettings()
        {
            //Get Size and Description window settings
            var myReg = openRegistryKey(RegAdressBase);

            //Make sure we got a valid key
            if (myReg != null)
            {
                //Get Sorting settings
                var sortColumn = myReg.GetValue(KeySortColumn);
                if (sortColumn != null)
                {
                    SortColumn = (int)sortColumn;
                }

                var sortOrder = myReg.GetValue(KeySortOrder);
                if (sortOrder != null)
                {
                    SortOrder = (SortOrder)Enum.Parse(typeof(SortOrder), sortOrder.ToString());
                }
            }

            //Rename the old registry key if exists
            renameOldSettings();

            //Check if we have old column settings that need to be converted
            convertOldColumnSettings();
            
            //Get column list
            myReg = openRegistryKey(RegAdressColumnsDisplay);
            ColumnsDisplay = new Dictionary<int, int>();

            //Make sure we got a valid key
            if (myReg == null)
            {
                return;
            }

            foreach (var valueName in myReg.GetValueNames())
            {
                ColumnsDisplay.Add(int.Parse(valueName), int.Parse(myReg.GetValue(valueName).ToString()));
            }
        }

        /// <summary>
        /// Saves all settings.
        /// </summary>
        public void SaveAllSettings()
        {
            //Create / Open registry key for base settings
            var myReg = openRegistryKey(RegAdressBase, true);

            //Make sure we got a valid key
            if (myReg != null)
            {
                //If we have a form size
                if (!FormSize.IsEmpty)
                {
                    myReg.SetValue(KeyWidth, FormSize.Width);
                    myReg.SetValue(KeyHeight, FormSize.Height);
                }

                myReg.SetValue(KeyHideDescription, HideDescription);
                myReg.SetValue(KeyDescriptionHeight, DescriptionHeight);

                myReg.SetValue(KeySortColumn, SortColumn);
                myReg.SetValue(KeySortOrder, SortOrder);

                myReg.SetValue(KeyIncludeSummary, IncludeSummary);
            }


            //Create / Open registry key for Column List settings
            myReg = openRegistryKey(RegAdressColumnsDisplay, true, true);

            //Make sure we got a valid key
            if (myReg == null)
            {
                return;
            }

            //Store Column Names and index
            foreach (var column in ColumnsDisplay)
            {
                myReg.SetValue(column.Key.ToString(), column.Value);
            }
        }


        /// <summary>
        /// Gets a list of the most recently selected items
        /// </summary>
        public static string[] GetRecentItems()
        {
            //Get list of recent items
            var myReg = openRegistryKey(RegAdressRecent);
            var recentItems = new List<string>();

            //Make sure we got a valid key
            if (myReg != null)
            {
                //Build list of recent items
                foreach (var item in myReg.GetValueNames())
                {
                    recentItems.Add((string)myReg.GetValue(item));
                }
            }

            return recentItems.ToArray();
        }

        /// <summary>
        /// Saves the list of the currently selected items
        /// </summary>
        /// <param name="listItems">The list of items</param>
        public static void SaveRecentItems(IEnumerable<FeedItem> listItems)
        {
            //Create new recent items list
            var myReg = openRegistryKey(RegAdressRecent, true, true);

            if (myReg == null)
            {
                return;
            }

            //Store issue number and description
            foreach (var itItem in listItems)
            {
                myReg.SetValue(itItem.Number.ToString(), itItem.Description);
            }
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Opens the registry key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private static RegistryKey openRegistryKey(string key)
        {
            return openRegistryKey(key, false, false);
        }

        /// <summary>
        /// Opens the registry key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="createIfNotExists">if set to <c>true</c> [create if not exists].</param>
        /// <returns></returns>
        private static RegistryKey openRegistryKey(string key, bool createIfNotExists)
        {
            return openRegistryKey(key, createIfNotExists, false);
        }

        /// <summary>
        /// Opens the registry key.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="createIfNotExists">if set to <c>true</c> [create if not exists].</param>
        /// <param name="deleteExistingKeyFirst">if set to <c>true</c> [delete existing key first].</param>
        /// <returns></returns>
        private static RegistryKey openRegistryKey(string key, bool createIfNotExists, bool deleteExistingKeyFirst)
        {
            //Delete Existing key first if exists
            if (deleteExistingKeyFirst)
            {
                Registry.CurrentUser.DeleteSubKey(key, false);
            }

            //Create or Open Registry Key
            RegistryKey myReg;
            try
            {
                myReg = createIfNotExists ? Registry.CurrentUser.CreateSubKey(key) : Registry.CurrentUser.OpenSubKey(key);
            }
            catch
            {
                //If can not open registry key then simply return
                return null;
            }

            return myReg;
        }

        /// <summary>
        /// Recursively copies a registry key.
        /// </summary>
        /// <param name="sourceKey">The source key.</param>
        /// <param name="destinationKey">The destination key.</param>
        private static void recursiveCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
        {
            //copy all the values
            foreach (var valueName in sourceKey.GetValueNames())
            {
                var objValue = sourceKey.GetValue(valueName);
                var valKind = sourceKey.GetValueKind(valueName);
                destinationKey.SetValue(valueName, objValue, valKind);
            }

            //For Each subKey create a new subKey in destinationKey (recursive)
            foreach (var sourceSubKeyName in sourceKey.GetSubKeyNames())
            {
                using (var sourceSubKey = sourceKey.OpenSubKey(sourceSubKeyName))
                {
                    using (var destSubKey = destinationKey.CreateSubKey(sourceSubKeyName))
                    {
                        recursiveCopyKey(sourceSubKey, destSubKey);
                    }
                }
            }
        }

        #endregion
    }
}
