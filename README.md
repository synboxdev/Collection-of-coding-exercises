# <b><font size="7">Collection of coding exercises</font></b>

## <b><font size="6">📄 Table of contents</font></b>
* ## [About the project](#about-the-project)
* ## [Getting started](#getting-started)
    * ### [Downloading the repository](#downloading-the-repository)
    * ### [Starting the project](#starting-the-project)
* ## [Technology stack](#technology-stack)
* ## [Contributing](#Contributing)
* ## [Code of Conduct](#Code-of-Conduct)

### <b><font size="6">About the project</font></b>

'Collection of coding exercises' is a command-line based project, which is a collection of solutions, to a variety of different exercises in different subjects/areas that one might encounter during an exam, technical interview or perhaps in pursuit of some extra programming practice.

Motive is to provide an accessible, nicely structured and documented project, that would be easy to navigate, and would provide users with well-written, functional and tested solutions, with necessary comments and explanations.

Functionality, readability and simplicity are, and should be, the main focus of solutions to any and all exercises. Performance and efficiency are also imporant, but realistically speaking those are non-factors to these one-off, isolated problems and exercises that are being solved. However, suggestions or solutions that specifically focus on performance are always welcome.

---

### <b><font size="6">Getting started</font></b>

#### <b><font size="5">Downloading the repository</font></b>

To get you started, you must first clone the repository (download it your own machine). You can do this by a number of methods, here's a few:
<br><br>
<font size="4">Method 1 - Downloading zipped repository and extracting it locally:</font>
<br>
[Download](https://github.com/synboxdev/Collection-of-coding-exercises/archive/refs/heads/master.zip) zipped repository, and extract the files to a folder of your choosing.
<br><br>
<font size="4">Method 2 - Using [Windows CLI](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/cmd) to download the repository:</font>
<br>
1. Open up <b>Cmd.exe</b>
2. Navigate to an empty folder of your choosing
```
cd C:\Users\DeveloperUser\Desktop\MyEmptyFolder
```
3. Execute a command that clones (downloads a copy) the repository to your current directory
```
git clone https://github.com/synboxdev/Collection-of-coding-exercises.git
```
<br>

<font size="4">Method 3 - Using <b>Visual Studio</b> (2022/2019) built-in terminal </font>
1. Open up Visual Studio
2. Open up the Terminal (View > Terminal)
3. Make sure you're navigated to a directory where you want the repository to be downloaded to
```
cd C:\Users\DeveloperUser\Desktop\MyEmptyFolder
```
If your directory names has spaces inside, execute the command as follows
```
cd "cd C:\Users\DeveloperUser\Desktop\My Projects\MyEmptyFolder"
```
4. Execute a command that clones (downloads a copy) the repository to your current directory
```
git clone https://github.com/synboxdev/Collection-of-coding-exercises.git
```
<br>

<font size="4">Method 4 - Using <b>Visual Studio Code</b> built-in terminal</font>
1. Open up Visual Studio Code
2. Open up the Terminal (View > Terminal)
3. Make sure you're navigated to the directory where you want the repository to be downloaded to
```
cd C:\Users\DeveloperUser\Desktop\MyEmptyFolder
```
If your directory names has spaces inside, execute the command as follows
```
cd "cd C:\Users\DeveloperUser\Desktop\My Projects\MyEmptyFolder"
```
4. Execute a command that clones (downloads a copy) the repository to your current directory
```
git clone https://github.com/synboxdev/Collection-of-coding-exercises.git
```
<br>

---

#### <b><font size="5">Starting the project</font></b>

<font size="4">Method 1 - Continuing to use any terminal (Windows CLI, Visual Studio or Visual Studio Code):</font>
1. Now that you've successfully downloaded the repository, you must navigate further inside the solution's project files, to start up the project. Exeucte the following command, inside the terminal, to navigate to a correct location inside the project:
```
cd Collection-of-coding-exercises/Core
```
2. Run the project by executing the following command:
```
dotnet run
```
3. Once the project is up and running, use it and enjoy it to your heart's content! Execute command <b>help</b> to get you started, and follow any and all information that the project provides you.

<font size="4">Method 2 - Using <b>Visual Studio</b></font>
1. Open up the project's .sln file, which is navigated in <b>~\Collection-of-coding-exercises\Core</b> (File > Open > Project/Solution), or simply navigate to the directory yourself, and double-click <b>Collection of coding exercises.sln</b> which should open up in <b>Visual Studio</b>
2. Make sure that <b>Core</b> project is selected as Startup Project - Open Solution Explorer (View > Solution Explorer), right-click on <b>Core</b> and select option 'Set and Startup Project'.
3. Start the project (Debug > Start Without Debugging)

---

### <b><font size="5">Technology stack</font></b>

As mentioned in the introductory description of the project, this is inherently a relatively simple project, which primarely focuses on the complexity of the exercises themselves, instead of over-arching architecture of the project. Howevery, here's the technologies that were used in the making of this project:

* ### [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) 
* ### [.NET 7 Framework](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* ### [Console App project](https://en.wikipedia.org/wiki/Console_application)
* ### [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) / [Visual Studio Code](https://code.visualstudio.com/)
* ### [Git](https://learn.microsoft.com/en-us/devops/develop/git/what-is-git) / [Sourcetree](https://www.sourcetreeapp.com/)

Project, more specifically - solutions for the exercises thus far has been built, and will continue to be built, using only [standard framework libraries](https://learn.microsoft.com/en-us/dotnet/standard/framework-libraries), with the exception of unit tests, which are utilizing [Moq Framework](https://learn.microsoft.com/en-us/shows/visual-studio-toolbox/unit-testing-moq-framework) and [xUnit.net](https://xunit.net/) tools for input and output testing of our solutions.

Reasoning for this is relatively simple - main focus of the project is to solve variety of exercises and programming problems, using the standard set of tools available right out of the box using the .NET framework, and not rely on some third party libraries, extensions or tools.

---

### <b><font size="5">Contributing</font></b>
Any and all positive contributions are welcome, including features, issues, documentation, guides, and more. See [Contributing documentation](CONTRIBUTING.md) for more details.

---

### <b><font size="5">Code of Conduct</font></b>
This project and everyone participating in it is governed by the [Code of Conduct](CODE_OF_CONDUCT.md). By participating and contributing the the project and its contents, you are expected to uphold this code.