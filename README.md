# hydroseed
hydroseed is a tool to create seed dat files from seeddb.bin 

## why?
Many CIAs from the CDN require seeds to run. FBI can download seeds from the official servers, however that doesn't do much good if you don't have/want wireless connectivity. FBI can also import seeds from SD:/fbi/seed/\<titleid\>.dat, but .dat files are hard to come by as other tools use seeddb.bin. Until FBI supports seeddb.bin files, hydroseed can help you out.

hydroseed is very simple - it downloads seeddb.bin files from urls listed in a text file and dumps all seeds to fbi/seed/\<titleid\>.txt 

## how to use 
1. Download and extract the program
2. Edit seedsources.txt to contain the urls to seeddb.bin files. One per line.
3. Run the program.
4. You now have a folder called fbi contianing a seed folder containing dats.
5. Copy fbi folder to the root of your sd card.
6. FBI will now import seeds from your sd card when installing CIAs or selecting import.

## releases
hydroseed is written in C#.

### hydroseed-win32
The win32 release requires .NET Framework 4.5.2 and runs on Windows.

From a command prompt run:
`hydroseed.exe`

### hydroseed-portable
The portable release requires .NET Core 2.0 and runs on all Linux, Windows, and OSX.

From a command prompt run:
`dotnet hydroseed.dll`
