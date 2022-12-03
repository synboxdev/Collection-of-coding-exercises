# <b>Collection of coding exercises</b>

## <b>Table of contents</b>
* 💡 [About the project](#about-the-project)
* ⚙️ [Getting started](#getting-started)
    * [Downloading the repository](#downloading-the-repository)
    * [Starting the project](#starting-the-project)

### 💡 <b>About the project</b>

'Collection of coding exercises' is a command-line based project, which a collection of solutions, to a variety of different exercises in different subjects/areas that one might encounter during an exam, technical interview or perhaps in pursuit of some extra programming practice.

Primary goal is to provide an accessible, nicely structured and documented project, that would be easy to navigate, and would provide users with well-written, functional and tested solutions, with necessary comments and explanations.

### ⚙️ <b>Getting started</b>

#### <b>Downloading the repository</b>

To get you started, you must first clone the repository (download it your own machine). You can do this by a number of methods, here's a few:

Method 1 - Downloading zipped repository and extracting it locally: <br>
[Download](https://github.com/synboxdev/Collection-of-coding-exercises/archive/refs/heads/master.zip) zipped repository, and extract the files to a folder of your choosing.

Method 2 - Using [Windows CLI](https://learn.microsoft.com/en-us/windows-server/administration/windows-commands/cmd) to download the repository: <br>
1. Open up <b>Cmd.exe</b>
2. Navigate to an empty folder of your choosing
```
cd C:\Users\DeveloperUser\Desktop\MyEmptyFolder
```
3. Execute a command that clones (downloads a copy) the repository to your current directory
```
git clone https://github.com/synboxdev/Collection-of-coding-exercises.git
```

Method 3 - Using <b>Visual Studio</b> (2022/2019) built-in terminal
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

Method 5 - Using <b>Visual Studio Code</b> built-in terminal
1. Open up Visual Studio Code
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

#### <b>Starting the project</b>

Method 1 - Continuing to use any terminal (Windows CLI, Visual Studio or Visual Studio Code):
1. Now that you've successfully downloaded the repository, you must navigate further inside the solution's project files, to start up the project. Exeucte the following command, inside the terminal, to navigate to a correct location inside the project:
```
cd Collection-of-coding-exercises/Core
```
2. Run the project by executing the following command:
```
dotnet run
```
3. Once the project is up and running, use it and enjoy it to your heart's content! Execute command <b>help</b> to get you started, and follow any and all information that the project provides you.

Method 2 - Using <b>Visual Studio</b>
1. Open up the project's .sln file, which is navigated in <b>~\Collection-of-coding-exercises\Core</b> (File > Open > Project/Solution), or simply navigate to the directory yourself, and double-click <b>Collection of coding exercises.sln</b> which should open up in <b>Visual Studio</b>
2. Make sure that <b>Core</b> project is selected as Startup Project - Open Solution Explorer (View > Solution Explorer), right-click on <b>Core</b> and select option 'Set and Startup Project'.
3. Start the project (Debug > Start Without Debugging)