using System;
using System.Collections.Generic;

namespace hydroseed
{
    public class SeedDB
    {
        public int Count { get; set; }

        public List<Seed> Seeds { get; set; } = new List<Seed>();

        public SeedDB(){}
        public SeedDB(byte[] seedData)
        {
            this.Load(seedData);
        }
        public int Load(byte[] seedData){
            Count = BitConverter.ToInt32(seedData, 0);

            for (int i = 0; i < Count; i++)
            {
                var title = new byte[8];
                var seedValue = new byte[16];
                Buffer.BlockCopy(seedData, 0x10 + (0x20 * i), title, 0, 8);
                Buffer.BlockCopy(seedData, 0x18 + (0x20 * i), seedValue, 0, 16);
                if (BitConverter.IsLittleEndian)
                {
                    Array.Reverse(title);
                }
                Seeds.Add(
                    new Seed()
                    {
                        TitleId = BitConverter.ToString(title).Replace("-",String.Empty),
                        SeedValue = seedValue
                    }
                );

            }
            return 0;
        }

    }
    public class Seed
    {
        public string TitleId { get; set; }
        public byte[] SeedValue { get; set; }

    }
}