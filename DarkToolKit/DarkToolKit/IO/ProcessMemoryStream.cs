using System;
using System.Diagnostics;
using System.IO;
using Ernegien.HaloOnline.Utilities.Imports;

namespace Ernegien.HaloOnline.Utilities.IO
{
    // TODO: cleanup

    /// <summary>
    /// Allows for the reading and writing of memory in a process.
    /// </summary>
    public unsafe class ProcessMemoryStream : Stream
    {
        #region Fields

        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly IntPtr _processHandle;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly BinaryReader _reader;
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private readonly BinaryWriter _writer;

        #endregion

        #region Properties

        public IntPtr ProcessHandle
        {
            get { return _processHandle; }
        }

        public override long Position { get; set; }

        public override long Length
        {
            get { throw new NotSupportedException(); }
        }

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanSeek
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return true; }
        }

        #endregion

        #region Constructor

        public ProcessMemoryStream(IntPtr processHandle)
        {
            _processHandle = processHandle;
            _reader = new BinaryReader(this);
            _writer = new BinaryWriter(this);
        }

        #endregion

        #region Methods

        public override void Flush()
        {
            // do nothing
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            switch (origin)
            {
                case SeekOrigin.Begin:
                    Position = offset;
                    break;
                case SeekOrigin.Current:
                    Position += offset;
                    break;
                default:
                    throw new InvalidOperationException();
            }
            return Position;
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            int bytesRead;
            fixed (byte* pBuffer = buffer)
            {
                Kernel32.ReadProcessMemory(_processHandle, (UIntPtr)Position, pBuffer + offset, count, out bytesRead);
            }
            Position += bytesRead;
            return bytesRead;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            fixed (byte* pBuffer = buffer)
            {
                int bytesWritten;
                Kernel32.WriteProcessMemory(_processHandle, (UIntPtr)Position, pBuffer + offset, count, out bytesWritten);
                Position += bytesWritten;
            }
        }

        #endregion

        #region Supplemental Methods

        public bool ReadBoolean()
        {
            return _reader.ReadBoolean();
        }

        public bool ReadBoolean(long address)
        {
            Position = address;
            return _reader.ReadBoolean();
        }

        public char ReadChar()
        {
            return _reader.ReadChar();
        }

        public char ReadChar(long address)
        {
            Position = address;
            return _reader.ReadChar();
        }

        public char[] ReadChars(int count)
        {
            return _reader.ReadChars(count);
        }

        public char[] ReadChars(long address, int count)
        {
            Position = address;
            return _reader.ReadChars(count);
        }

        public byte ReadByte(long address)
        {
            Position = address;
            return _reader.ReadByte();
        }

        public byte[] ReadBytes(int count)
        {
            return _reader.ReadBytes(count);
        }

        public byte[] ReadBytes(long address, int count)
        {
            Position = address;
            return _reader.ReadBytes(count);
        }

        public decimal ReadDecimal()
        {
            return _reader.ReadDecimal();
        }

        public decimal ReadDecimal(long address)
        {
            Position = address;
            return _reader.ReadDecimal();
        }

        public double ReadDouble()
        {
            return _reader.ReadDouble();
        }

        public double ReadDouble(long address)
        {
            Position = address;
            return _reader.ReadDouble();
        }

        public short ReadInt16()
        {
            return _reader.ReadInt16();
        }

        public short ReadInt16(long address)
        {
            Position = address;
            return _reader.ReadInt16();
        }

        public int ReadInt32()
        {
            return _reader.ReadInt32();
        }

        public int ReadInt32(long address)
        {
            Position = address;
            return _reader.ReadInt32();
        }

        public Int64 ReadInt64()
        {
            return _reader.ReadInt64();
        }

        public Int64 ReadInt64(long address)
        {
            Position = address;
            return _reader.ReadInt64();
        }

        public sbyte ReadSByte()
        {
            return _reader.ReadSByte();
        }

        public sbyte ReadSByte(long address)
        {
            Position = address;
            return _reader.ReadSByte();
        }

        public float ReadSingle(long address)
        {
            Position = address;
            return _reader.ReadSingle();
        }

        public float ReadSingle()
        {
            return _reader.ReadSingle();
        }

        public ushort ReadUInt16()
        {
            return _reader.ReadUInt16();
        }

        public ushort ReadUInt16(long address)
        {
            Position = address;
            return _reader.ReadUInt16();
        }


        public uint ReadUInt32()
        {
            return _reader.ReadUInt32();
        }

        public uint ReadUInt32(long address)
        {
            Position = address;
            return _reader.ReadUInt32();
        }

        public void WriteBoolean(long address, bool value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteBoolean(bool value)
        {
            _writer.Write(value);
        }

        public void WriteByte(long address, byte value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteChar(char value)
        {
            _writer.Write(value);
        }

        public void WriteChar(long address, char value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteUInt16(long address, ushort value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteUInt16(ushort value)
        {
            _writer.Write(value);
        }

        public void WriteUInt32(long address, uint value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteUInt32(uint value)
        {
            _writer.Write(value);
        }

        public void WriteUInt64(long address, UInt64 value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteUInt64(UInt64 value)
        {
            _writer.Write(value);
        }

        public void WriteInt64(long address, long value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteSingle(long address, float value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteSingle(float value)
        {
            _writer.Write(value);
        }

        public void WriteDouble(long address, double value)
        {
            Position = address;
            _writer.Write(value);
        }

        public void WriteDouble(double value)
        {
            _writer.Write(value);
        }

        public void WriteNops(long address, int count)
        {
            Position = address;
            byte[] nops = new byte[count];
            for (int i = 0; i < nops.Length; i++)
            {
                nops[i] = 0x90;
            }
            Write(nops, 0, nops.Length);
        }

        public void Write(long address, params object[] values)
        {
            Position = address;
            foreach (object obj in values)
            {
                switch (Convert.GetTypeCode(obj))
                {
                    case TypeCode.Boolean:
                    case TypeCode.Byte:
                    case TypeCode.Char: WriteByte(Convert.ToByte(obj)); break;
                    case TypeCode.Int16:
                    case TypeCode.UInt16: WriteUInt16(Convert.ToUInt16(obj)); break;
                    case TypeCode.Int32:
                    case TypeCode.UInt32: WriteUInt32(Convert.ToUInt32(obj)); break;
                    case TypeCode.Int64:
                    case TypeCode.UInt64: WriteUInt64(Convert.ToUInt64(obj)); break;
                    case TypeCode.Single: WriteSingle(Convert.ToSingle(obj)); break;
                    case TypeCode.Double: WriteDouble(Convert.ToDouble(obj)); break;
                    case TypeCode.Object:
                        // TODO: revisit this
                        byte[] bytes = obj as byte[];
                        if (bytes != null) Write(bytes, 0, bytes.Length);
                        else throw new InvalidOperationException("Invalid datatype.");
                        break;
                    default: throw new InvalidOperationException("Invalid datatype.");
                }
            }
        }

        #endregion
    }
}
