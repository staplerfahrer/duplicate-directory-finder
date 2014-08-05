duplicate-directory-finder
==========================

Finding duplicate files is easy. Finding directories that are duplicates is hard. And finding a fast program with parallel hashing is even harder. I wrote DuplicateDirectoryFinder to solve that problem for me and my many drives and backups.

This program is written in C#, and I used Visual Studio Express 2013 to write it.

I highly recommend getting Lennert Ploeger's TreeComp (http://lploeger.home.xs4all.nl/TreeComp.htm) to quickly diff the discovered directories and quickly eliminate duplicates that way - I have also used WinMerge but it doesn't do as good of a job at displaying subdirectories.

I do not recommend changing the CPU type for this program, when scanning terabytes of files you'll see that the resulting file dictionary quickly grows and can easily exceed 2 GB - which can't be stored in memory if the project is built for x86 CPUs.
