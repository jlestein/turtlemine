# Adding BugTraq properties to your repository #

See the BugTraq wiki page for details as to what BugTraq is. Also note that these instructions illustrate setting this up for Tortoise SVN.  It is a similar process in Tortoise Git and Tortoise Hg.

## Setup / Import ##
  * Download the sample BugTraq file from the [downloads](http://code.google.com/p/turtlemine/downloads/list) tab above.
  * Browse to The folder containing the _repository_ you wish to hook up BugTraq to your Redmine issues list. The root most folder of your repository is the best place to do this.
  * Right click on the folder and go the   **Properties** under the **TortoiseSVN** menu.

![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq01.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq01.png)


  * In the Properties dialog box click on   **Import**.

![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq02.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq02.png)


  * Browse to the sample properties file that you downloaded and click ok to import it.
  * you will need to update one property.
  * For the _bugtraq:url_ you will need to **change** this to the URL of your Redmine server.  It is important to note that you need to keep the "/issues/%BUGID%" after the server location.

![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq03.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq03.png)


  * In order for the properties to apply to the whole repository instead of just the selected folder you need to click on **edit** and select **Apply Property Recursively**.

![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq04.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq04.png)


  * **You will now need to commit the changes to your repository.**

_**Note**: In some cases you may receive an error when you try and commit if your repository is out of date so you will need to do an update before you can commit._

## Usage / Benefits ##

Adding BugTraq to your repository gives you a few new useful features.  Primarily it gives you a link between TortoiseSVN/Git/Hg and your Redmine issues.
This connection is provided in two ways:

  * It provides clickable links to your Redmine issues directly in your commit dialog window or log messages window.

![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq05.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq05.png)


  * It adds a Bug ID column to your log messages window that allows you to easily see, sort and filter on the issue id number that you associated with commit.

![http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq06.png](http://turtlemine.googlecode.com/svn/trunk/Images/Screenshots/bugtraq06.png)