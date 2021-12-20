<p align="center">
    <img src="https://github.com/VelouriasMoon/QueenIO/blob/main/Images/LogoLight.png#gh-light-mode-only" width="300"/>
    <img src="https://github.com/VelouriasMoon/QueenIO/blob/main/Images/LogoDark.png#gh-dark-mode-only" width="300"/>
</p>

# About QueenIO
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/donate?hosted_button_id=7LVCJCM9LNQ2W)<br/>
QueenIO is a data managing library for many data tables found in Code Vein, using [UAssetAPI](https://github.com/atenfyr/UAssetAPI) as a backend, to allow ease of access editing for important data tables like the Inner List, Mask List, and more.

# Usage
QueenIO uses it's own version of UAssetAPI's Uasset called Relics, Relics are always Versioned as Unreal 4.18 and have addional functions for handling the Data Table.  
Use QueenIO's Blood code for opening and saving files without needing to go through UAssetAPI code.  
Basic example on loading a file, adding a new entry to the Inner list, and saving the file:
```cs
private void AddEntryToInner(string infile)
{
    Relic relic = new Relic();                          //Creates a new memory struct for a uasset
    relic = Blood.Open(infile)                          //Opens the given files and Reads it as a Relic
    InnerList Inner = new InnerList();                  //Crate a new memory struct for the Inner list 
    Inner.Read(relic.GetDataTable());                   //Reads the Inner List data from the Relic

    InnerData data = new InnerData();                   //Crate a new Inner object and add some data
    data.Name = "Inner_Female9";
    data.Thumbnail = "/Game/UserInterface/T_Thumb_Inner_Female009.T_Thumb_Inner_Female009";
    data.Mesh = "/Game/Costumes/Inners/Inner_Female9/Meshes/SK_Inner_Female9.SK_Inner_Female9";

    Inner.Inners.Add(data);                             //Add the new Inner to the Inner List
    relic.WriteDataTable(Inner.Make())                  //Set the Data Table as the New Inner List
    Blood.Save(relic, infile)                           //Writes the Relic to the given Path
}
```

# Dependencies
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework)  
- [UAssetAPI](https://github.com/atenfyr/UAssetAPI) for Building
- UAsset/UExp Files from Code Vein

# Building
1. Download both the Source code from QueenIO and [UAssetAPI](https://github.com/atenfyr/UAssetAPI)
2. Open the QueenIO.sln in Visual Studio
3. Fix the UAssetAPI reference to where you unpack it if need be
4. Build the file by right clicking on the solution name in the Solition Explorer

# Credits
[UAssetAPI](https://github.com/atenfyr/UAssetAPI) Really the Back bone to the whole thing by providing an easy to use uasset phraser.
