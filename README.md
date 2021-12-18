<p align="center">
    <img src="https://github.com/VelouriasMoon/QueenIO/blob/main/Images/LogoLight.png#gh-light-mode-only" width="300"/>
    <img src="https://github.com/VelouriasMoon/QueenIO/blob/main/Images/LogoDark.png#gh-dark-mode-only" width="300"/>
</p>

# About QueenIO
[![Donate](https://img.shields.io/badge/Donate-PayPal-green.svg)](https://www.paypal.com/donate?hosted_button_id=7LVCJCM9LNQ2W)<br/>
QueenIO is a data managing library for many data tables found in Code Vein, using [UAssetAPI](https://github.com/atenfyr/UAssetAPI) as a backend, to allow ease of access editing for important data tables like the Inner List, Mask List, and more.

# Usage
Basic example on loading a file, adding a new entry to the Inner list, and saving the file:
```cs
private void AddEntryToInner(string infile)
{
    UAsset asset = new UAsset(UE4Version.VER_UE4_18);   //Creates a new memory struct for a uasset
    asset.FilePath = infile;
    asset.Read(asset.PathToReader(asset.FilePath));     //Reads the given uasset
    InnerList Inner = new InnerList();                  //Crate a new memory struct for the Inner list 
    Inner.Read((DataTableExport)asset.Exports[0]);      //Reads the Inner List data from the uasset

    InnerData data = new InnerData();                   //Crate a new Inner object and add some data
    data.Name = "Inner_Female9";
    data.Thumbnail = "/Game/UserInterface/T_Thumb_Inner_Female009.T_Thumb_Inner_Female009";
    data.Mesh = "/Game/Costumes/Inners/Inner_Female9/Meshes/SK_Inner_Female9.SK_Inner_Female9";

    Inner.Inners.Add(data);                             //Add the new Inner to the Inner List
    ((DataTableExport)asset.Exports[0]).Table = Inner.Make(); //Set the Data Table as the New Inner List
    SaveFile(asset, infile);
}

private void SaveFile(UAsset asset, string path)
{
    bool loop = true;
    while (loop)
    {
        loop = false;
        try
        {
            asset.Write(path);
            return;
        }
        catch (NameMapOutOfRangeException ex)
        {
            try
            {
                asset.AddNameReference(ex.RequiredName);
                loop = true;
            }
            catch (Exception ex2)
            {

            }
        }
        catch (Exception ex)
        {

        }
    }
}
```

# Dependencies
- [.NET Framework 4.8](https://dotnet.microsoft.com/download/dotnet-framework)  
- [UAssetAPI](https://github.com/atenfyr/UAssetAPI) for Building
- UAsset/UExp Files from Code Vein

# Credits
[UAssetAPI](https://github.com/atenfyr/UAssetAPI) Really the Back bone to the whole thing by providing an easy to use uasset phraser.
