# WordPerfectTools
Template to interact with WordPerfect using WinForms, including simple examples of how to automate WP from .NET  
This code base is different from WordPerfectTools_SingleVersion by implementing the ability to operate on multiple versions of WordPerfect.  Currently, it works on the x4, x6, x7 and x8 versions of WordPerfect.

The WordPerfect.PerfectScript interface for each version is implemented using the Factory Pattern, by which the calling application first figures out which version of WordPerfect is installed on the user machine, and then instantiates the relevant WordPerfect interface using a shared abstract class called GenericPerfectScript.

The drawback to this implementation is that the hundreds of generated WordPerfect enumerations are no longer available, and will create compilation errors on existing code that use those enumerations.  So the programmer has to convert each enumeration to its integer equivalent by looking up the command reference file.

This program is an educational tool for those wishing to automate WordPerfect by
using a form that captures an instance of WP.  The program has several sample GUI tools that provide different
ways of accessing and modifying a WordPerfect document.  The sample GUI functions can also be stripped, leaving a functioning
empty template for you to create your own custom application to automate WordPerfect.

Don't bother trying to compile and run the code unless you have a version of WordPerfect installed on your machine.

For a detailed discussion of the code for C# newbies, see the WPUniverse forums.

To get the sample letter generator to work correctly, copy and paste the SampleMergeLetter.wpt file from the WP_GUI project into the WP_GUI\bin\Debug folder after compiling.  Git for some reason does not upload these files, and I got tired of trying to figure out where to store that file for easy access by the program.
