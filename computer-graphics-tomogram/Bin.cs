using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace computer_graphics_tomogram
{
    class Bin
    {
        public static int x, y, z;
        public static short[] array;
        public static short[,,] arrayNEW;
        public Bin() { }

        public void readBin(string path)
        {
            if (File.Exists(path))
            {
                BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));
                x = reader.ReadInt32();
                y = reader.ReadInt32();
                z = reader.ReadInt32();

                int arraySize = x * y * z;
                array = new short[arraySize];
                arrayNEW = new short[x, y, z];
                for (int k = 0; k < z; k++)
                    for (int j = 0; j < y; j++)
                        for (int i = 0; i < x; i++)
                            arrayNEW[i, j, k] = reader.ReadInt16();
            }
        }
    }
}
