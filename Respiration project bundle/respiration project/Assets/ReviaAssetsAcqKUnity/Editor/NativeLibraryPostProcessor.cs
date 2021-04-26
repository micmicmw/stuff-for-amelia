using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.IO;

public class NativeLibraryPostProcessor
{

    [InitializeOnLoad]
    public class Startup
    {
        static Startup()
        {
            if (Environment.OSVersion.Platform == PlatformID.Unix || Environment.OSVersion.Platform == PlatformID.MacOSX)
            {
                DeployDYLIB(System.Environment.CurrentDirectory, "86;64");
            }
        }
    }

    [PostProcessSceneAttribute(2)]
    public static void OnPostprocessScene()
    {
        if (Environment.OSVersion.Platform == PlatformID.Unix ||
           Environment.OSVersion.Platform == PlatformID.MacOSX)
        {
            DeployDYLIB(System.Environment.CurrentDirectory, "86;64");
      
        }
    }


    [PostProcessBuildAttribute(1)]
    public static void OnPostprocessBuild(BuildTarget target, string pathToBuiltProject)
    {
		// for mac anyway, removing the last part because this will be the package file, not really the dir
		pathToBuiltProject = Path.GetDirectoryName (pathToBuiltProject);

        switch (target)
        {
            case BuildTarget.StandaloneOSXIntel64:
                DeployDYLIB(pathToBuiltProject, "64");
                break;
            case BuildTarget.StandaloneOSX:
                DeployDYLIB(pathToBuiltProject, "64;86");
                break;
            case BuildTarget.StandaloneOSXIntel:
                DeployDYLIB(pathToBuiltProject,"86");
                break;
            case BuildTarget.StandaloneWindows:
            case BuildTarget.StandaloneWindows64:
                break;
            case BuildTarget.StandaloneLinux64:
            case BuildTarget.StandaloneLinuxUniversal:
                break;
            default:
                break;
        }
        Debug.Log(pathToBuiltProject);
    }

    private static void DeployDYLIB(string path, string which)
    {
        foreach (var libFile in GetLibFiles(which))
        {
            try
            {
				string dst = Path.Combine((path), Path.GetFileName(libFile));
                if (!File.Exists(dst))
    				File.Copy(libFile, dst, true);
            }
            catch
            {
            }
        }
    }

    private static IEnumerable<string> GetLibFiles(string which)
    {
        if (which.Contains("64"))
            foreach (var el in System.IO.Directory.GetFiles(System.IO.Path.GetFullPath("."), "*LexActivator64*.dylib", System.IO.SearchOption.AllDirectories))
            {
                yield return (el);
            }
        if (which.Contains("86"))
            foreach (var el in System.IO.Directory.GetFiles(System.IO.Path.GetFullPath("."), "*LexActivator*.dylib", System.IO.SearchOption.AllDirectories))
            {
                yield return (el);
            }
    }
}
