# Installation / Setup #

## Install ##
  * Download the installer from the [downloads](http://code.google.com/p/turtlemine/downloads/list) tab above.
  * Run the installer; with Vista/Windows 7 This may require accepting UAC windows.
  * Accept the License Agreement (if you agree with it) _MIT LICENSE_.
  * Continue the installation to completion.

## Setup ##

### Prerequisites ###

  * TortoiseSVN
  * Something using TortoiseSVN (A Working Repository)
  * Basic understanding of terms like "Working Directory / Repository"

### Configuring the TortoiseSVN Redmine Plugin ###

  * Browse to The folder containing the _repository_ you wish to hook up to your Redmine issues list.
  * Right click on the folder and go to **Settings** under the **TortoiseSVN** menu.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn01.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn01.png)


  * In the Settings dialog, select **Issue Tracking Integration** and click the **Add** button.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn02.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn02.png)


  * To _configure Issue Tracker Integration_ for TurtleMine you need to specify three values.
    1. Set the _Working Copy Path_ to the local repository location.
    1. Set the _Provider_ to the **TurtleMine** Provider.  (If this is the only provider you have it will most likely be pre-selected).
    1. Set the _Parameters_ field to the **ATOM Feed URL** from your Redmine Issues Page for the issues that you wish to be available to include in your commit comments. (See below for more details).

#### To get the ATOM Feed URL ####
  * Browse to the issue list you wish to use.
  * At the bottom of the page will be a link to the **ATOM Feed** for the page.  Right click on this link and copy the URL or shortcut.
  * Paste this URL into the _Parameters_ field mentioned above.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn03.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn03.png)


  * Your final configuration should look something like the below.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn04.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn04.png)

  * Click on the _Options_ button to test your connection or configure connectivity options. (this step is optional)
    * Click _Test_ to test the connection to Redmine and retrieval of the issues list.
  * Click on _Connection Settings_ to expand the Connection Settings options to configure your Proxy Server, Authentication, or SSL requirements.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn05.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn05.png)

![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn06.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn06.png)


  * Once you click OK and return to the Tortoise SVN window, you should now see the listing in the Issue Tracking Integration list.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn07.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn07.png)


### Using the basic functions of TurtleMine ###

  * Bring up the TortoiseSVN commit dialog as you would normally do so.  There will be a new **Redmine Issues** button at the top right of the dialog window.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn08.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn08.png)


  * Click the Redmine Issues button to bring up the TurtleMine window.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn09.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn09.png)

  * Here you will be able to select a Redmine issue to include in your commit message.  Some of the functionality is listed below.
    * A) A basic search box to search within the issues.
    * B) A drop down list to choose which fields to search on, the default is all fields.
    * C) A Next button to move the selection through the found results.
    * D) A Check button to select (check) all highlighted or found issues.
    * E) The main issue list display window.
    * F) The Issue Description window (this is hidden by default, See _I_ for details).
    * G) Opens your default web browser to the page for the selected Redmine issue.
    * H) Opens your default web browser to the page for Time Entry page for the selected Redmine issue.
    * I) Toggles the description window visibility.
    * J) If selected, includes the issue summary text as well as the issue number in your commit message.
    * K) _Ok_, to add the selected issues to your commit message, otherwise _Cancel_ adding issues.

  * You can also right click in the main issue list window to bring up display customization options.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn10.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn10.png)


  * Select the issue number you wish to include then click **OK**.  The Issue number/s will be appended to the end of your existing commit message.
![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn11.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/tsvn11.png)