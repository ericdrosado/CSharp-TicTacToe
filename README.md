## Debug C# Tic-Tac-Toe Utilizing Minimax Algorithm

### Instructions
Writing clean Object Oriented code is a must, but reading code is also a skill that new developers must learn in order to collaborate effectively with other team members.

In this assignment you will be exposed to a nearly complete Tic-Tac-Toe Game that utilizes the Minimax Algorithm. Your assignment is to review the source code that was written, using Object Oriented Programming, and determine why the game is not functioning as expected and fix it.


#### Setup
1. You will write this code with a AWS Cloud9 environment. Please, log-in to your [AWS Educate](https://www.awseducate.com/signin/SiteLogin) account to do this.
2. Go to our [Classroom](https://www.awseducate.com/student/s/classrooms)
3. Open the AWS Console
4. Open Cloud9 and create a Cloud9 environment and name it `Debug C# Tic-Tac-Toe Assignment`
5. Keep all the default configuration settings
6. Once, your environment is created, download .NET Core 2 SDK into your environment by typing the following on the command line:
```
sudo yum -y update
sudo yum -y install libunwind
curl -O https://dot.net/v1/dotnet-install.sh
sudo chmod u=rx dotnet-install.sh
./dotnet-install.sh -c Current
```
7. Update the `.bashrc` where is says `export PATH` to look like the following: 
`export PATH=$PATH:$HOME/.local/bin:$HOME/bin:$HOME/.dotnet`
8. Load the .NET Core 2 SDK by sourcing the `.bashrc` file by typing this on the command line: `. ~/.bashrc`
9. Clone this repository into your AWS Cloud9 environment

#### To run:
+ In the root directory:
```
dotnet run --project TicTacToe/TicTacToe.csproj
```
#### To exit:
+ While in the game:
` ctrl + c `

#### To run tests:
+ In the root directory:
```
dotnet test Tests
```
