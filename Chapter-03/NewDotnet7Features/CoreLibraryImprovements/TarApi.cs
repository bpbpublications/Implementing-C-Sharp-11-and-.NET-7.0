using System.Formats.Tar;
using System.IO.Compression;

namespace CoreLibraryImprovements;

public static class TarApi
{
    public static void CreateTarFile(
        string sourceDirectoryName, 
        string destinationFileName)
    {
        TarFile.CreateFromDirectory(
            sourceDirectoryName: sourceDirectoryName, 
            destinationFileName: destinationFileName, 
            includeBaseDirectory: true);
    }

    public static void ExtractTarFile(
        string sourceFileName,
        string destinationDirectoryName)
    {
        TarFile.ExtractToDirectory(
            sourceFileName: sourceFileName,
            destinationDirectoryName: destinationDirectoryName,
            overwriteFiles: false);
    }

    public static void CreateTarFileFromStream(
        string sourceDirectoryName,
        string destinationDirectoryName)
    {
        using var stream = new MemoryStream();
        TarFile.CreateFromDirectory(
            sourceDirectoryName: sourceDirectoryName,
            destination: stream,
            includeBaseDirectory: true);
        
        TarFile.ExtractToDirectory(
            source: stream,
            destinationDirectoryName: destinationDirectoryName,
            overwriteFiles: false);
    }

    public static void TransferFilesToDifferentArchive(
        string sourceFileName,
        string destinationFileName)
    {
        using var stream = File.OpenRead(sourceFileName);
        using var reader = new TarReader(stream, leaveOpen: false);

        TarEntry? entry;
        while ((entry = reader.GetNextEntry()) != null)
        {
            destinationFileName = Path.Join(destinationFileName, entry.Name);
            entry.ExtractToFile(destinationFileName, overwrite: true);
        }
    }

    public static void ExtractFromGzipArchive(
        string sourceFileName,
        string destinationDirectoryName)
    {
        using var compressedStream = File.OpenRead(sourceFileName);
        using var decompressor = new GZipStream(compressedStream, CompressionMode.Decompress);
        TarFile.ExtractToDirectory(
            source: decompressor,
            destinationDirectoryName: destinationDirectoryName,
            overwriteFiles: false);
    }
}