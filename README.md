# Collection of coding exercises

## 📄 Table of contents

* [About the project](#about-the-project)
* [Getting started](#getting-started)
    * [Downloading the repository](#downloading-the-repository)
    * [Starting the project](#starting-the-project)
* [Project Euler](#project-euler)
* [Technology stack](#technology-stack)
* [Contributing](#Contributing)
* [Code of Conduct](#code-of-conduct)

## About the project

'Collection of coding exercises' is a command-line based project, which is a collection of solutions, to a variety of different exercises in different subjects/areas that one might encounter during an exam, technical interview or perhaps in pursuit of some extra programming practice.

Motive is to provide an accessible, nicely structured and documented project, that would be easy to navigate, and would provide users with well-written, functional and tested solutions, with necessary comments and explanations.

Functionality, readability and simplicity are, and should be, the main focus of solutions to any and all exercises. Performance and efficiency are also important, but realistically speaking those are non-factors to these one-off, isolated problems and exercises that are being solved. However, suggestions or solutions that specifically focus on performance are always welcome.

Additionally, this project also contains solutions for 'Project Euler'. I saw the need to mention it separately, since its not 'regular' type of problems and solutions per-se. See more in section [Project Euler](#project-euler)

---

## Getting started

### Downloading the repository

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

### Starting the project

<font size="4">Method 1 - Continuing to use any terminal (Windows CLI, Visual Studio or Visual Studio Code):</font>
1. Now that you've successfully downloaded the repository, you must navigate further inside the solution's project files, to start up the project. Execute the following command, inside the terminal, to navigate to a correct location inside the project:
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

## Project Euler

### What is Project Euler?

Project Euler is a series of challenging mathematical/computer programming problems that will require more than just mathematical insights to solve. Although mathematics will help you arrive at elegant and efficient methods, the use of a computer and programming skills will be required to solve most problems.

The motivation for starting Project Euler, and its continuation, is to provide a platform for the inquiring mind to delve into unfamiliar areas and learn new concepts in a fun and recreational context.

### Who are the problems aimed at?

The intended audience include students for whom the basic curriculum is not feeding their hunger to learn, adults whose background was not primarily mathematics but had an interest in things mathematical, and professionals who want to keep their problem solving and mathematics on the cutting edge.

### Can anyone solve the problems?

The problems range in difficulty and for many the experience is inductive chain learning. That is, by solving one problem it will expose you to a new concept that allows you to undertake a previously inaccessible problem. So the determined participant will slowly but surely work his/her way through every problem.

### Credit & Copyright

 * As mentioned above, all credit for these exercises goes to <b>https://projecteuler.net/about</b>. 
 * The problem content on the site is licensed under a Creative Commons (CC) License. More details here: <b>https://projecteuler.net/copyright</b> 

---

## Technology stack

As mentioned in the introductory description of the project, this is inherently a relatively simple project, which primarily focuses on the complexity of the exercises themselves, instead of over-arching architecture of the project. However, here's the technologies that were used in the making of this project:

* #### [C#](https://learn.microsoft.com/en-us/dotnet/csharp/) 
* #### [.NET 7 Framework](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
* #### [Console App project](https://en.wikipedia.org/wiki/Console_application)
* #### [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) / [Visual Studio Code](https://code.visualstudio.com/)
* #### [Git](https://learn.microsoft.com/en-us/devops/develop/git/what-is-git) / [Sourcetree](https://www.sourcetreeapp.com/)

Project, more specifically - solutions for the exercises thus far have been built, and will continue to be built, using only [standard framework libraries](https://learn.microsoft.com/en-us/dotnet/standard/framework-libraries), with the exception of unit tests, which utilize [Moq Framework](https://learn.microsoft.com/en-us/shows/visual-studio-toolbox/unit-testing-moq-framework) and [xUnit.net](https://xunit.net/) tools for input/output testing of our solutions.

Reasoning for this is simple - main focus of the project is to solve a variety of exercises and programming problems, using the standard set of tools available right out of the box using the .NET framework, and not rely on third party libraries, extensions or tools.

---

## Contributing
Any and all positive contributions are welcome, including features, issues, documentation, guides, and more. See [Contributing documentation](CONTRIBUTING.md) for more details.

---

## Code of Conduct
This project and everyone participating in it is governed by the [Code of Conduct](CODE_OF_CONDUCT.md). By participating and contributing the the project and its contents, you are expected to uphold this code.