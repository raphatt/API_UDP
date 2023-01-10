using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Text;

namespace API_UDP
{
    class API
    {
        private UInt32 PacketNumber;
        private UInt32 CategoryPacketNumber;
        private byte PartialPacketIndex;
        private byte PartialPacketNumber;
        private byte PacketVersion;
        private byte PacketType;

        public float sSpeed;
        public ushort sRpm;
        public byte sGearNumber;
        public int sMarcha;

        public void LerPacoteBase(Stream stream, BinaryReader binaryReader)
        {
            stream.Position = 0;
            PacketNumber = binaryReader.ReadUInt32();
            CategoryPacketNumber = binaryReader.ReadUInt32();
            PartialPacketIndex = binaryReader.ReadByte();
            PartialPacketNumber = binaryReader.ReadByte();
            PacketType = binaryReader.ReadByte();
            PacketVersion = binaryReader.ReadByte();
        }
        public void LerDados(Stream stream, BinaryReader binaryReader)
        {
            LerPacoteBase(stream, binaryReader);
            float KmMulti = (float)3.6;
            if (PacketType == 0)
            {
                stream.Position = 36;
                sSpeed = binaryReader.ReadSingle() * KmMulti;
                sRpm = binaryReader.ReadUInt16();
                stream.Position = 45;
                sGearNumber = binaryReader.ReadByte();
                sMarcha = sGearNumber & 15;
            }
        }
    }
}
