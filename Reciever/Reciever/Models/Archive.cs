using System;

namespace Reciever.Models
{
    public class Archive
    {
        public int Id { get; set; }
        public long Crc32 { get; set; }
        public int CompressedLength { get; set; }
        public int ExternalAttributes { get; set; }
        public string FullName { get; set; }
        public DateTime LastWriteTime { get; set; }
        public int Length { get; set; }
        public string Name { get; set; }
    }
}
