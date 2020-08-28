# PCBuildingSimulator
This is a project which is done while I right just enrolled my university. In this project, I made a GUI program with C# WinForm. Although it is an old technique, it's still convenient for us to make up an application demo soon. This project also involves some basic operations with Microsoft Access Database.



## 1，Requirement Analysis for System

### 1.1 The Background and Motivation of System

#### A) Raising Problem

Before starting our project, we made a survey among several computer repair shops. According to the result, various problems that customers meet can actually be solved by themselves, and it is not necessary for them to take their computer to a professional. However, they fail to solve them, or even realize them.

#### B) Analyzing Problem

The main reason for this is that many people have poor knowledge of computer structure and repairing. Hence, the basic knowledge of computer needs to be popularized among citizens.

#### C) Solving Problem

Therefore, we want to make a game to help people get familiar with common knowledge of computers. What we made is a simulated business game, where players run their own computer repairing shop. Our motivation of making this game, is to popularize some basic knowledge of computer and computer repairing, to the computer owners who know little about it, in an interesting, funny, easy and vivid way. Our orientation of this game is for civil education. Players should focus on the process of playing. Being familiar will the components of a computer and some basic operations are important for making a success.



### 1.2 System Objectives

The system will provide orders from customers to the player, by randomly selecting an event from the database. The attributes of all components (e.g. CPU, GPU) of the trouble computer should be initialized at the same time. The system should implement a function that allow players to remove the old components and install new ones and modify the attributes of the computers. The system will show the previous attribute values of every components of the computer when players click to see. For a few special components, an advertisement or a note will be shown as a bonus scene when players click to check the component. The system should provide tables of new components that players can choose to exchange the trouble ones of the computers. All the attributes of the components, such as model, capacity and power, should be listed clearly. The system should check whether the computer has been repaired successfully by the player, A function will be set to check all the attributes of the computer after repairing and decide whether the computer can be successfully switched on and work normally. If so, the “switch on” button in the users interface should be changed to “switch off”.



## 2，Program Analysis

### 2.1 Key Issues for System

#### A) Class and Hierarchy

Class Computer, the top base class of the system representing components of a computer, contains following data members: capacity, old(bool, decide whether the component is new or old), good(bool, decide whether the component is good or bad), which are common attributes for all components inside a computer. Get and set functions are provided for all of the private members. 

Class CPU, GPU, Memory, PSU, Mainboard, Harddisk, Software are derived classes directly inherit from base class Computer. Get and set functions are also provided. The data members are all the attributes of the component the classes represent (e.g. power, capacity, model, frequency).

Class SurpriseGPU derived from class GPU is for providing bonus scenes. The get function in this class is overridden to implement the function that it pops out pictures of ads or notes when the get function of some special types of GPU is called for the first time.

Class Event is a composite class, which includes objects of all the components classes as its data member. For each event, which is each order from a customer, the data members will be initialized by to represent the state of all the components of the trouble computer. Players try to repair the computer by changing the values of the data members.

Class Check takes object of class Event as its data member. This class is for checking the Event object and decide whether all the data members of it, which is, the component of the computer, are ready for the computer to start working normally.

In summary, inheritance, polymorphism and composition are the main features of the design of all the classes.

#### B) SQL and Database

Instead of file processing, we use the technique of database and SQL commands instead to improve the efficiency. Our database includes all the attributes of the components of various types. We used Microsoft Office Access to manipulate the database. We connect Access with C# by creating OledbConnection object, and runing SQL commands by creating OledbCommand object.

 

### 2.2 Duty Assignments

skipped......



## 3, Technical Routine

### 3.1 Runtime Environment

Windows 10 1903 Version, Visual studio 2019

Windows . net FrameWork



### 3.2 General Design

#### A) Class Hierarchy

<img src="https://i.loli.net/2020/08/29/vTUY1Q7e9C3VuOX.png" alt="image-20200829041847936" style="zoom: 150%;" />

##### ① the data members and constructors and set, get functions for all the classes

##### ② special: the constructor of class Event

##### ③ the function in class Check that check whether the computer is repaired successfully

#### B) Database and SQL Commands

We use Access to save our database and connect it with C# program. SQL commands are used to search and select information from the database. A class to read in the information is developed.

<img src="https://i.loli.net/2020/08/29/aQ4CfOGzSmquI5i.png" alt="image-20200829042016466" style="zoom:200%;" />

#### C) UI Design : the interface and the buttons

Photo1: the homepage

<img src="https://i.loli.net/2020/08/29/BleZ2dJijPXhtMn.png" alt="image-20200829042057813" style="zoom:150%;" />

Photo2: the main interface of the game

<img src="https://i.loli.net/2020/08/29/ZMSc1pfT6YROQEB.png" alt="image-20200829042340803" style="zoom:150%;" />

#### D) Bonus Scene 

##### ① the overridden getModel function in class SurpriseGPU

##### ② class surprise derived from class Form in System.Windows.Form is defined with member function to load the form.

##### ③ function ShowDialog to show the output



### 3.3 Detailed Design

#### A) Class Hierarchy

##### ① Data Members, Constructors and Member Functions

##### the following are the data members of base class Computer:

capacity; good *(bool, whether the component is good)*, old *(bool, whether the component is old)*;

 

##### the following are the data members of all classes for the components:

CPU: model; mainFrequency; power; cores; threads;

GPU: model; vram *(represents video memory)*; power;

Memory: capacity; frequency;

##### Mainboard: CPUInstall *(bool, whether the CPU has been installed in the mainboard)*; memoryNum *(the number of memories installed)*; GPUNum *(the number of GPUs installed)*; model;

PSU: ratedPower; conversionRate;

Harddisk: mechanics *(bool, whether the hard disk is SSD or mechanics)*; capacity;

Software: system *(bool, whether the operation system has been installed)*; virus *(bool, whether the computer is infected by virus)*;

Set functions and get functions for all the private members are defined in all the classes.

Example: interface IHarddisk and class Harddisk. All the other classes of components are similar to this.

<img src="https://i.loli.net/2020/08/29/OU2q1sRhun5TAcI.png" alt="image-20200829042610714" style="zoom:150%;" />

##### The following are the data members of class Events:

task *(string, the problem description from the customer)*; subject *(the result that whether the computer is normal or in trouble)*; c *(CPU)*; g *(GPU)*; m *(Mainboard)*; mem *(Memory)*; h *(Harddisk)*; p *(PSU)*; s *(Software)*;

Class Check takes Event object as its data member.

#### ② constructor of class Event

In the constructor of class Event, all the data members of the Event object, which are objects of all the components, are initialized according to different events (with multiple selection switch statements) that happens. All the information comes from our database and is gotten by SQL commands that have defined. The index of that data is decided by a random engine. The image shown is part of the constructor initializing data member task, subject and m (an object of class Mainboard). All the other members for components are initialized similarly as m. 

<img src="https://i.loli.net/2020/08/29/7dp4aPlfmqNobTK.png" alt="image-20200829042718723" style="zoom:150%;" />

#### ③ the function in class Check

The function that decides whether the computer has been well repaired by checking the following: whether all the components and system have been installed, whether all the components are good, whether the computer is till detected by virus and whether the number of components and other attributes like power are proper. Only when everything is normal can the computer be successfully turned on. The main part of the function is as the following:

<img src="https://i.loli.net/2020/08/29/5NOIcFWgTQJDoMf.png" alt="image-20200829042754683" style="zoom:200%;" />

### B) Database and SQL Commands

The data is saved in Access and designed SQL commands to search and get the aim information. Class database is developed with get_info as its member function, which connect the program with Access and read in information with SQL.

Fortunately, C# (or .net Framework) has offered us quite a number of tools to access to the databases. After learning some basic knowledge of database, we found that we can use the OledDB library to solve this problem.

<img src="https://i.loli.net/2020/08/29/7eWLsr2Z1PxOJQ8.png" alt="image-20200829042826011" style="zoom:150%;" />

As we can see in this photo, firstly we need to create the relative address and protocol for the database connection. The relative address means where we

store the local database, for example if we directly type “My_Database.mdb”, it is equal to “/C/Programme File/MyProgramme/Bin/My_Database/” (it is just an example, not the real one). So, after using this connection, we can get data from database by using SQL function, it is simple because our usage of the database is simple. But I choose another data type to get the result. Usually people use dataset to store all the data which are given back. But actually getting data from dataset also consumes computation and it is not flexible because we do not need to use the whole table at every time, why not use it individually since our computer is powerful enough to run plenty of SQL commands at the same time.

### C) UI Design

#### ① the start button

The picture changed a little bit after we place our mouse pointer onto it. To achieve this goal, we used a tricky technique that is called changing the picture while we place our mouse onto it, it is just two lines of codes, but it is this detail that make it more realistic isn’t it? Let’s have a look at how I achieve this.

To avoid copying the codes again and again, I made the procedure of changing pictures as a function, in which we can accept the status and react to it. The first parameter is the label of the button, “starting button”, “exiting button” or anything else. The second parameter is the label of the event, whether it is “mouse enter” or “mouse leave”.

<img src="https://i.loli.net/2020/08/29/QzsJbNU7amCjL12.png" alt="image-20200829042908432" style="zoom:150%;" />

#### ②button remove, install, switch-on and submit

Although this part sounds a little bit easy, it is hard to create new objects and it runs very slow because of several problems. The following is the design and codes behind these four little buttons and the tree table. The function sounds easy, but it is very complicated to make it come true. There are over 200 rows of codes to make it, let’s see the getInfo function:

<img src="https://i.loli.net/2020/08/29/oDcTh14tzKrpGYC.png" alt="image-20200829043126512" style="zoom:150%;" />

We need to think of every tree node and judge the cases. Firstly we want to use “switch” structure to do that because “switch” runs much faster than “if…else if”. This is the main problem! But each case contains multiple judgements, so we have to use “if…else if” instead of “switch”. Each component has to status, installed, uninstalled, and for each case we need to combine them with the labels to show. So we have to deal with lots of cases, that’s why our program runs a little bit slowly and stutter. By the way, all the buttons have similar codes behind, they are as follows.

<img src="https://i.loli.net/2020/08/29/kSCAH2aPyRzcQ5v.png" alt="image-20200829043214084" style="zoom:150%;" />

### D) Bonus Scene

If the GPU is of special kind, which can be known from the value provided by the random engine in class Event’s constructor, the new operator in the constructor of class Event will allocate a SurpriseGPU object to the data member g (type GPU).

There are several kinds of GPU that is SurpriseGPU. In the getModel function, the value super which defined in the class PCBS (the most outer class) will change according to the model of SurpriseGPU object. Then the Surprise_Load function in class surprise for loading the form will decide which picture in the resources to pop out and assign the value to pictureBox.BackgroundImage according the value of super. The following image is the main part of the definition of the overridden getModel function of class Surprise GPU. (Note: “hasShown==false” is in the following code)

<img src="https://i.loli.net/2020/08/29/AC3VsczBERmbGNv.png" alt="image-20200829043300403" style="zoom:150%;" />

The following is the main part of definition of Surprise_Load function in class surprise.

<img src="https://i.loli.net/2020/08/29/hYgcdXEPvjrSlfn.png" alt="image-20200829043320640" style="zoom:150%;" />



## 4, Testing Report

### 4.1 Function testing

####   1) getting a new event (initializing all the attributes of the computer and showing the problem description)

<img src="https://i.loli.net/2020/08/29/Ntdn4kj6RzAcaCU.png" alt="image-20200829043432832" style="zoom:150%;" />

#### 2) check if the computer has been repaired successfully (after repairing, the computer can be switched on, so it has been well repaired)

<img src="https://i.loli.net/2020/08/29/RTKMB9DW16INPxA.png" alt="image-20200829043501517" style="zoom:150%;" />

#### 3) bonus scene pop-outs when meet surprise GPU 

![image-20200829043526377](https://i.loli.net/2020/08/29/Uw6sPmztCJeKVGv.png)

All of these functions are executed correctly.



### 4.2 System testing

#### 1) showing the menu of previous components and the table of new components that players can select 

<img src="https://i.loli.net/2020/08/29/utJnXSeHFfbWNiq.png" alt="image-20200829043610855" style="zoom:150%;" />

#### 2) showing the state of the computer vividly: if any part of the computer is removed or installed

<img src="https://i.loli.net/2020/08/29/xlGKIkTSPHZYhbV.png" alt="image-20200829043643822" style="zoom:150%;" />

#### 3) showing the computer has been successfully repaired: the computer can be switched on, hence the switch on button will change into switch off button

<img src="https://i.loli.net/2020/08/29/STAf5sGOa4XHbCk.png" alt="image-20200829043715868" style="zoom:150%;" />![image-20200829043720860](https://i.loli.net/2020/08/29/RTKMB9DW16INPxA.png)

<img src="https://i.loli.net/2020/08/29/STAf5sGOa4XHbCk.png" alt="image-20200829043715868" style="zoom:150%;" />![image-20200829043720860](https://i.loli.net/2020/08/29/RTKMB9DW16INPxA.png)

#### 4) showing the bonus scene pop-outs (as has shown above)

#### 5) summary: the complete set of the processes (testing for all operations)

Obviously, we can click the start button to starting the game, and also we can click the quitting button to quit.

<img src="https://i.loli.net/2020/08/29/BCJNl7vGjYFU8QW.png" alt="image-20200829043826117" style="zoom:150%;" />

Note that the button start has changed a bit in color (become a little dimmer)

<img src="https://i.loli.net/2020/08/29/s3TtqJ27hzoxuv4.png" alt="image-20200829043843549" style="zoom:150%;" />

<img src="C:\Users\13540\AppData\Roaming\Typora\typora-user-images\image-20200829043910649.png" alt="image-20200829043910649" style="zoom:150%;" />

Now here comes the game main window, here we can see task and the hardware the computer already had. Read the task description and analyze which part is likely to be out of function, then just choose it, click “remove”, we can uninstall this component, then we need to choose a new one to install, then a new window of the table came out.

The table contains all the information for that kind of hardware such as CPU and so on, we need to check at its information and judge which one we should choose. Then type the ID to the blank and we can go back to the game window, we can finally see the new hardware has been installed.

After installing and repairing, we need to check the computer whether it works or not. So, we need to click on the “switch on” button, if it can be switched on, that means we successfully cure the hardware failure, but we can still turn it on with some virus in the computer, so please be careful. After we completely repair it, click the “submit” button to get the next task.

![image-20200829044035952](https://i.loli.net/2020/08/29/vg5FTx67CJ3uVMa.png)

![image-20200829044040114](https://i.loli.net/2020/08/29/Q4OrlP5DaI8MgKG.png)

Also, we have two patterns of each button, there is a logical procedure behind. For example, if a CPU is installed, the button of “install” is in grey, which means we cannot click this button. But at the same time, the button of “uninstall” is high-lighted, which means that we can remove it.

Above are all the operations. They all pass the test