# Software for testing optical fibers
## Developed by Shimon Luria and Meir Marzel.
[write to shimon](sh0527691229@gmail.com) [write to meir](meir4400@gmail.com)

This software was developed for the purpose of testing the software mounted on the fiber head for tracking and the integrity of the fiber. The software checks if the software installed on the fiber is correct and also checks if the fiber itself is correct and ready for operation and use.
 The software gives errors if problems are found including information and an explanation of the problem.
Each test is written to the test window when a byte address is written followed by the test data.
If the test came out normal, it is written in green, if there is a warning, it is written in black, and if there is an error, it is written in red.

At the moment the protocol only tests fibers burned according to the SFF 8636 protocol. [Here](https://members.snia.org/document/dl/26418) 
you can see the protocol. If you want to add another protocol, the software supports it and there is an infrastructure. What needs to be 
done are just these steps.

At the end of a run, the system allows you to output the result in Excel XML and DB format that can be
run using the SQLITE software.


## Installations:
- visual studio for developing and adding protocols. Can be downloaded from [here]().
- aardvark for drivers download from [here](https://www.totalphase.com/products/usb-drivers-windows/) and install it.
- SQLITE to manage the data. download fron [here](https://sqlitebrowser.org/dl/)

## adding new protocol
to add protocol to program: 
Markup:	1. create folder with the protocol name inside Protocol_classes folder
	2. create base abstract protocol class that inherit from Protocol.cs
	3. create all inherited classes, each class should implement all Protocol.cs functions.
	4. also create <protocol name>_manage.cs class the inherit from Protocol_manage interface
	5. add to Form1.cs the namespace of new created protocol folder
	6. in Form1.cs add to function SFFoptions_SelectedIndexChanged(), the new protocol