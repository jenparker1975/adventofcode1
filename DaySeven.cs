using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AdventOfCode1
{
    public class DaySeven
    {
        private class ElfFile
        {
            public ElfFile(string name, long size)
            {
                Name = name;
                Size = size;
            }

            public string Name { get; }
            public long Size { get; }
        }

        private class ElfDirTree
        {
            public ElfDirTree(string name)
            {
                Name = name;
                Children = new HashSet<ElfDirTree>();
                Files = new List<ElfFile>();
            }

            private ElfDirTree(string name, ElfDirTree parent)
            {
                Name = name;
                Parent = parent;
                Children = new HashSet<ElfDirTree>();
                Files = new List<ElfFile>();
            }

            private string Name { get; }
            //public long DirectorySize { get; private set; }
            public ElfDirTree Parent { get; }
            public HashSet<ElfDirTree> Children { get; }
            public List<ElfFile> Files { get; }
            //public override bool Equals(object? obj)
            //{
            //    return Name.Equals(((ElfDirTree) obj)?.Name);
            //}

            //public override int GetHashCode()
            //{
            //    return Name.GetHashCode();
            //}

            public void AddFile(string name, long fileSize)
            {   
                Files.Add(new ElfFile(name, fileSize));
            }

            public ElfDirTree ChangeDirectory(string name)
            {
                var newChildNode = new ElfDirTree(name, this);
                Children.Add(newChildNode);
                return Children.FirstOrDefault(s => s.Name == name);
            }
        }

        //private static long getSmallDirs(ElfDirTree directory, long targetSize)
        //{
        //    long result = 0;
        //    if (directory.Size < targetSize)
        //        result = directory.Size;

        //    result += directory.Children.Sum(child => getSmallDirs(child, targetSize));

        //    return result;
        //}

        //private static long getDirToDelete(ElfDirTree dir, long sizeRequired, long currentSmallest)
        //{
        //    var result = currentSmallest;
        //    if (dir.Size >= sizeRequired && dir.Size < currentSmallest)
        //        result = dir.Size;
        //    return dir.Children.Aggregate(result, (current, child) => getDirToDelete(child, sizeRequired, current));
        //}

        public static void CalculateSizes()
        {
            ElfDirTree root = new ElfDirTree("/");
            ElfDirTree currentDir = root;

            var lines = File.ReadAllLines(@"D:\source\adventofcode1\files.txt");
            
            foreach (var line in lines)
            {
                var bits = line.Split(' ');
                switch (bits[0])
                {
                    case "$":
                    {
                        if (bits[1] == "cd")
                        {
                            switch (bits[2])
                            {
                                    case "/":
                                        currentDir = root;
                                        break;
                                    case "..":
                                        currentDir = currentDir.Parent;
                                        break;
                                    default:
                                        currentDir = currentDir.ChangeDirectory(bits[2]);
                                        break;
                            }
                        }

                        if (bits[1] == "ls")
                        {

                        }
                        break;
                    }
                    case "dir":
                        break;
                    default:
                        currentDir.AddFile(bits[1], long.Parse(bits[0]));
                        break;
                }
            }

            //long sizeRequired = 30_000_000 - (70_000_000 - root.Size);
            //long result;
            //result = getSmallDirs(root, 100_000);
            //result = getDirToDelete(root, sizeRequired, long.MaxValue);
            //Console.WriteLine(result);

        }
    }
}
