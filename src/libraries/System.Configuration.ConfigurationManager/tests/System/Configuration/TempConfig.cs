// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;

namespace System.Configuration
{
    public class TempConfig : IDisposable
    {
        private readonly TempDirectory _directory;

        public TempConfig(string contents)
        {
            _directory = new TempDirectory();
            ExePath = Path.Combine(_directory.Path, Path.GetRandomFileName() + ".exe");
            File.WriteAllText(ExePath, "dummy exe");
            ConfigPath = ExePath + ".config";
            File.WriteAllText(ConfigPath, contents);
        }

        public string ConfigPath { get; }
        public string ExePath { get; }

        public void Dispose()
        {
            _directory?.Dispose();
        }
    }
}
