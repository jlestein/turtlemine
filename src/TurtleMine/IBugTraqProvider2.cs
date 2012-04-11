using System;
using System.Runtime.InteropServices;

namespace Interop.BugTraqProvider
{
	/// <summary>
	/// Provides an updated BugTraq interface
	/// </summary>
	[ComImport, InterfaceType( ComInterfaceType.InterfaceIsIUnknown ), Guid( "C5C85E31-2F9B-4916-A7BA-8E27D481EE83" )]
	internal interface IBugTraqProvider2 : IBugTraqProvider
	{
		/// <summary>
		/// Validates the parameters.
		/// </summary>
		/// <param name="hParentWnd">Parent window for any UI that needs to be displayed during validation.</param>
		/// <param name="parameters">The parameter string that needs to be validated.</param>
		/// <returns>Is the string valid?</returns>
		[return: MarshalAs(UnmanagedType.VariantBool)]
		new bool ValidateParameters(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);

		/// <summary>
		/// Gets the link text.
		/// </summary>
		/// <param name="hParentWnd">Parent window for any (error) UI that needs to be displayed.</param>
		/// <param name="parameters">The parameter string, just in case you need to talk to your web service (e.g.) to find out what the correct text is.</param>
		/// <returns>What text do you want to display? Use the current thread locale.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetLinkText(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);

		/// <summary>
		/// Gets the commit message.
		/// </summary>
		/// <param name="hParentWnd">Parent window for your provider's UI.</param>
		/// <param name="parameters">Parameters for your provider.</param>
		/// <param name="commonRoot">The common root.</param>
		/// <param name="pathList">The path list.</param>
		/// <param name="originalMessage">The text already present in the commit message. Your provider should include this text in the new message, where appropriate.</param>
		/// <returns>The new text for the commit message. This replaces the original message.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		new string GetCommitMessage(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string originalMessage);

		/// <summary>
		/// Gets the commit message2.
		/// </summary>
		/// <param name="hParentWnd">Parent window for your provider's UI.</param>
		/// <param name="parameters">Parameters for your provider.</param>
		/// <param name="commonURL">The common URL of the commit.</param>
		/// <param name="commonRoot">The common root.</param>
		/// <param name="pathList">The path list.</param>
		/// <param name="originalMessage">The text already present in the commit message. Your provider should include this text in the new message, where appropriate.</param>
		/// <param name="bugID">The content of the <paramref name="bugID"/> field (if shown)</param>
		/// <param name="bugIDOut">Modified content of the <paramref name="bugID"/> field.</param>
		//You can assign custom revision properties to a commit by setting the next two params.  note: Both safearrays must be of the same length.   For every property name there must be a property value!
		/// <param name="revPropNames">The list of revision property names.</param>
		/// <param name="revPropValues">The list of revision property values.</param>
		/// <returns>The new text for the commit message. This replaces the original message.</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		string GetCommitMessage2(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters,
			[MarshalAs(UnmanagedType.BStr)] string commonURL,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string originalMessage,
			[MarshalAs(UnmanagedType.BStr)] string bugID,
			[MarshalAs(UnmanagedType.BStr)] out string bugIDOut,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] revPropNames,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] out string[] revPropValues);

		/// <summary>
		/// Checks the commit.
		/// </summary>
		/// <param name="hParentWnd">The h parent WND.</param>
		/// <param name="parameters">The parameters.</param>
		/// <param name="commonURL">The common URL.</param>
		/// <param name="commonRoot">The common root.</param>
		/// <param name="pathList">The path list.</param>
		/// <param name="commitMessage">The commit message.</param>
		/// <returns></returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		string CheckCommit(IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters,
			[MarshalAs(UnmanagedType.BStr)] string commonURL,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string commitMessage);

		/// <summary>
		/// Called when [commit finished].
		/// </summary>
		/// <param name="hParentWnd">Parent window for any (error) UI that needs to be displayed.</param>
		/// <param name="commonRoot">The common root of all paths that got committed.</param>
		/// <param name="pathList">All the paths that got committed.</param>
		/// <param name="logMessage">The text already present in the commit message.</param>
		/// <param name="revision">The revision of the commit.</param>
		/// <returns>An error to show to the user if this function returns something else than S_OK</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		string OnCommitFinished(
			IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string commonRoot,
			[MarshalAs(UnmanagedType.SafeArray, SafeArraySubType = VarEnum.VT_BSTR)] string[] pathList,
			[MarshalAs(UnmanagedType.BStr)] string logMessage,
			[MarshalAs(UnmanagedType.U4)] int revision);

		/// <summary>
		/// Whether the provider provides options
		/// </summary>
		/// <returns>
		/// 	<c>true</c> if this instance has options; otherwise, <c>false</c>.
		/// </returns>
		[return: MarshalAs(UnmanagedType.VariantBool)]
		bool HasOptions();

		/// <summary>
		/// Shows the options dialog.
		/// </summary>
		/// <param name="hParentWnd">Parent window for the options dialog.</param>
		/// <param name="parameters">Parameters for your provider.</param>
		/// <returns>The parameters string</returns>
		[return: MarshalAs(UnmanagedType.BStr)]
		string ShowOptionsDialog(
			IntPtr hParentWnd,
			[MarshalAs(UnmanagedType.BStr)] string parameters);
	} 
}